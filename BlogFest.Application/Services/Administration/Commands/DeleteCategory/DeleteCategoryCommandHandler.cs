using BlogFest.Application.Abstract;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Administration.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<SuccessInfo, Error>>
    {
        private readonly IUserContext _userContext;
        private readonly IManagerRepository _managerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUserContext userContext, IManagerRepository managerRepository, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _managerRepository = managerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<SuccessInfo, Error>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.CurrentUserId;
            var manager = await _managerRepository.GetManagerByIdAsync(userId);

            var result = manager.RemoveCategory(request.Id);

            await _managerRepository.Update(manager);
            await _unitOfWork.SaveAsync();

            return result;
        }
    }
}
