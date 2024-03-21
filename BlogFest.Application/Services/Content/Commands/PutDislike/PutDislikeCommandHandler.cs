using MediatR;
using BlogFest.Domain.Base;
using BlogFest.Domain.Content.ContentConsuming;
using BlogFest.Application.Abstract;

namespace BlogFest.Application.Services.Content.Commands.PutDislike
{
    public class PutDislikeCommandHandler : IRequestHandler<PutDislikeCommand, Result<bool, Error>>
    {
        private readonly IContentConsumerRepository _contentRepository;
        private readonly IUserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        public PutDislikeCommandHandler(IContentConsumerRepository contentRepository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            _contentRepository = contentRepository;
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<bool, Error>> Handle(PutDislikeCommand request, CancellationToken cancellationToken)
        {
            var user = await _contentRepository.GetContentConsumerById(_userContext.CurrentUserId, request.PostId);

            var result = user.PutDislike();

            await _contentRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return result;

        }
    }
}
