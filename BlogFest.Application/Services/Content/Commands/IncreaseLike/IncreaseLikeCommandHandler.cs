using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content.ContentCreating;
using BlogFest.Domain.Content.ContentConsuming;
using BlogFest.Application.Abstract;

namespace BlogFest.Application.Services.Content.Commands.IncreaseLike
{
    public class IncreaseLikeCommandHandler : IRequestHandler<IncreaseLikeCommand, Result<bool, Error>>
    {
        private readonly IContentConsumerRepository _contentRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        public IncreaseLikeCommandHandler(IContentConsumerRepository contentRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _contentRepository = contentRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool, Error>> Handle(IncreaseLikeCommand request, CancellationToken cancellationToken)
        {
            var user = await _contentRepository.GetContentConsumerById(_userContext.CurrentUserId, request.PostId);

            var result = user.PutLike();

            await _contentRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
