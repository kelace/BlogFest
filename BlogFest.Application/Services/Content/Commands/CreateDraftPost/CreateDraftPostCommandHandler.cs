using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Users;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Application.Abstract;

namespace BlogFest.Application.Services.Content.Commands.CreateDraftPost
{
    public class CreateDraftPostCommandHandler : IRequestHandler<CreateDraftPostCommand, Result<SuccessInfo, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IContentCreatorRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISlugCreator _slugCreator;

        public CreateDraftPostCommandHandler(IUserRepository userRepository, IContentCreatorRepository postRepository, IUnitOfWork unitOfWork, ISlugCreator slugCreator)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _slugCreator = slugCreator;
        }
        public async Task<Result<SuccessInfo, Error>> Handle(CreateDraftPostCommand request, CancellationToken cancellationToken)
        {
            var user = await _postRepository.GetContentCreatorById(request.UserId);

            var slug = _slugCreator.CreateSlug(Post.DefaultTitle);
            var result = user.CreateDraftPost(slug);

            if (result.IsError) return result.Error;

            //await _userRepository.Update(user);
            await _postRepository.UpdateAsync(user);

            await _unitOfWork.SaveAsync();

            return new SuccessInfo
            {
                Id = result.Value.Id,
                Slug = await _postRepository.GetSlugForPost(result.Value.Id),
			};

		}
    }
}
