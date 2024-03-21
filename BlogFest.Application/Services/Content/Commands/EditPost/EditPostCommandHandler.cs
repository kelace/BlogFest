using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Application.Abstract;

namespace BlogFest.Application.Services.Content.Commands.EditPost
{
    public class EditPostCommandHandler : IRequestHandler<EditPostCommand, Result<SuccessInfo, Error>>
    {
        private readonly IContentCreatorRepository _contentRepository;
        private readonly IUserContext _userContenxt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISlugCreator _slugCreator;
        public EditPostCommandHandler(IUserContext userContenxt, IUnitOfWork unitOfWork, IContentCreatorRepository contentRepository, ISlugCreator slugCreator)
        {
            _userContenxt = userContenxt;
            _unitOfWork = unitOfWork;
            _contentRepository = contentRepository;
            _slugCreator = slugCreator;
        }
        public async Task<Result<SuccessInfo, Error>> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var contentCreator = await _contentRepository.GetContentCreatorById(_userContenxt.CurrentUserId);

            if (contentCreator == null) throw new NullReferenceException("Content creator doesn't exist while an id from the coockies is reachable");

            var slug = _slugCreator.CreateSlug(request.Title);

            var editResult = contentCreator.EditPost(request.PostId, request.ContentText, request.ContentHTML, request.Title, slug, request.Categories, request.ImageId, request.Status);

            if (editResult.IsError) return editResult;

            await _contentRepository.UpdateAsync(contentCreator);

            await _unitOfWork.SaveAsync();

            return editResult;
        }
    }
}
