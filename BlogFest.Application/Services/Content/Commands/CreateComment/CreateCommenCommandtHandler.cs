using MediatR;
using BlogFest.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogFest.Domain.Content.ContentConsuming;
using BlogFest.Application.Abstract;
using BlogFest.Domain.Base;

namespace BlogFest.Application.Services.Content.Commands.CreateComment
{
    public class CreateCommenCommandtHandler : IRequestHandler<CreateCommentCommand, Result<SuccessInfo, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IContentConsumerRepository _contentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateCommenCommandtHandler
            (IUserRepository userRepository,
            IContentConsumerRepository contentRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            _userRepository = userRepository;
            _contentRepository = contentRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Result<SuccessInfo, Error>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var contentConsumer = await _contentRepository.GetContentConsumerById(request.UserId, request.PostId);

            var result = contentConsumer.WriteComment(request.CommentContent);

            if (result.IsError) return result;

            await _contentRepository.UpdateAsync(contentConsumer);

            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
