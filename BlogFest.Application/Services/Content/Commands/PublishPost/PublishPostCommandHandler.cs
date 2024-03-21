using BlogFest.Application.Abstract;
using BlogFest.Domain.Base;
using MediatR;
using BlogFest.Domain.Content.ContentCreating;

namespace BlogFest.Application.Services.Content.Commands.PublishPost
{
    public class PublishPostCommandHandler : IRequestHandler<PublishPostCommand, Result<SuccessInfo, Error>>
    {
        private readonly IContentCreatorRepository _contentCreatorRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContentCreatorRepository _creatorRepository;
        public PublishPostCommandHandler(IContentCreatorRepository contentCreatorRepository, IUserContext userContext, IUnitOfWork unitOfWork, IContentCreatorRepository creatorRepository)
        {
            _contentCreatorRepository = contentCreatorRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
            _creatorRepository = creatorRepository;
        }

        public async Task<Result<SuccessInfo, Error>> Handle(PublishPostCommand request, CancellationToken cancellationToken)
        {
            var user = await _contentCreatorRepository.GetContentCreatorById(_userContext.CurrentUserId);

            var result = user.PublishPost(request.PostId);

            await _creatorRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
