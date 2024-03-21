using BlogFest.Application.Abstract;
using MediatR;
using BlogFest.Application.Services.Users.DTOs;
using BlogFest.Application.Services.Content.Queries.DTOs;
using BlogFest.Domain.Content;
using BlogFest.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Dapper;

namespace BlogFest.Application.Services.Users.Queries.GetUserPageByName
{
    public class GetUserPageByNameQueryHandler : IRequestHandler<GetUserPageByNameQuery, UserPageDTO>
    {
        private readonly IUserContext _userContext;
        private readonly string _connection;
        public GetUserPageByNameQueryHandler(
            IOptions<DbConfigurationOptions> dbConfiguration,
            IUserContext userContext)
        {
            _userContext = userContext;
            _connection = dbConfiguration.Value.ConnectionString;
        }

        public async Task<UserPageDTO> Handle(GetUserPageByNameQuery request, CancellationToken cancellationToken)
        {
            var model = new UserPageDTO();

            var sql = $@"
                        SELECT COUNT(c.Id) FROM (
                            SELECT ci.Id FROM {DbConstants.PostTable} as ci
                            left join {DbConstants.UserTable} cu on ci.UserId = cu.Id
                            WHERE case
                            when @Name is not null and @Name = cu.Name then 1
                            else 0
                            end = 1
                            AND CASE
                                WHEN ci.UserId != @CurrentUserId AND ci.PostStatus = @DraftStatus THEN 0
                                WHEN ci.UserId = @CurrentUserId AND ci.PostStatus = @DraftStatus THEN 1
                            ELSE 1    
                            END = 1
                        ) AS c; 

                        SELECT u.Id, u.Name, UserFile.Path, u.Bio, u.Active as IsActive, p.Id, p.Slug, p.Title, p.UserId, p.Status, p.DateCreated, ISNULL(fp.Path, dfp.Path) as ImagePath, p.Text FROM {DbConstants.UserTable} u
                        OUTER APPLY (
                            SELECT Posts.Id, Posts.Title, Posts.UserId, Posts.PostStatus as Status, Posts.DateCreated, Posts.Slug, SUBSTRING(Posts.ContentText, 0, 200) as Text  FROM {DbConstants.PostTable} Posts 
                                WHERE
                                CASE
                                    WHEN Posts.UserId != @CurrentUserId AND Posts.PostStatus = @DraftStatus THEN 0
                                    WHEN Posts.UserId = @CurrentUserId AND Posts.PostStatus = @DraftStatus THEN 1
                                ELSE 1    
                                END = 1
                            and Posts.UserId = u.Id
                            ORDER BY Posts.No desc
                            OFFSET @Offset ROWS FETCH NEXT @Next ROWS ONLY
                        ) as p
                        OUTER APPLY
                        (
                       		SELECT ISNULL(uffs.Path, dffs.Path) as Path FROM dbo.Users ui
							LEFT JOIN {DbConstants.UserFileTable} ufs on ui.Id = ufs.UserId  and ufs.Choosed = 1
                            left JOIN {DbConstants.FileTable} uffs on ufs.FileId = uffs.Id 
                            LEFT JOIN  {DbConstants.FileTable} dffs on dffs.Name = 'Default-Image'
                            where ui.Id =  u.Id
                        ) AS UserFile
						LEFT JOIN {DbConstants.PostFileTable} pf on pf.PostId = p.Id and pf.Active = 1
                        LEFT JOIN {DbConstants.FileTable} fp on pf.FileId = fp.Id
		                LEFT JOIN {DbConstants.FileTable} dfp on dfp.Type = @DefaultFileType
                        LEFT JOIN dbo.AspNetUserRoles ur on u.Id = ur.UserId
                        LEFT JOIN dbo.AspNetRoles r on ur.RoleId = r.Id
                        WHERE case
                            when @Name is not null and @Name = u.Name then 1
                            else 0
                            end = 1;
                        ";

            using (var connection = new SqlConnection(_connection))
            {

                using (var reader = await connection.QueryMultipleAsync(sql, new
                {
                    Name = request.Name,
                    DraftStatus = PostStatus.Draft.ToString(),
                    CurrentUserId = _userContext.CurrentUserId,
                    Offset = (request.Page - 1) * 3,
                    Next = 3,
                    DefaultFileType = MediaTypes.ImageTitlePreview
                }))
                {
                    var res1 = await reader.ReadSingleAsync<int>();
                    var res2 = reader.Read<UserDTO, PostDTO, UserDTO>((user, post) =>
                    {
                        if (model.Posts == null)
                        {
                            model.Posts = new List<PostDTO>();
                        }

                        if (post != null)
                        {
                            model.Posts.Add(post);
                        }

                        return user;
                    }, splitOn: "Id");

                    var result = res2.GroupBy(x => x.Id).Select(x =>
                    {
                        var groupedUsers = x.FirstOrDefault();
                        return groupedUsers;
                    });

                    var userModel = result.FirstOrDefault();

                    if (userModel is null) return null;

                    model.CommonAmount = res1;
                    model.User = userModel;
                }
            }

            if (model != null) model.Page = request.Page;
            if (model != null && _userContext.CurrentUserId == model.User.Id) model.IsUserAccount = true;

            return model;
        }
    }
}
