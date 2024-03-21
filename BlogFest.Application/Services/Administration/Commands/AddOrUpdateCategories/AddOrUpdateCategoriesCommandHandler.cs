using BlogFest.Application.Abstract;
using BlogFest.Application.Services.Administration.Commands.AddCategories;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Base;
using MediatR;

namespace BlogFest.Application.Services.Administration.Commands.AddOrUpdateCategories
{
    public class AddOrUpdateCategoriesCommandHandler : IRequestHandler<AddOrUpdateCategoriesCommand, Result<SuccessInfo, Error>>
    {
        private readonly IUserContext _userContext;
        private readonly IManagerRepository _managerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrUpdateCategoriesCommandHandler(IUserContext userContext, IManagerRepository managerRepository, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _managerRepository = managerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SuccessInfo, Error>> Handle(AddOrUpdateCategoriesCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.CurrentUserId;
            var manager = await _managerRepository.GetManagerByIdAsync(userId);
            var categories = request.Categories.Select(x =>
            {
                return new Category(x.Id, x.Title, x.Enabled);
            }).ToList();

            manager.AddOrUpdateCategories(categories);

            await _managerRepository.Update(manager);
            await _unitOfWork.SaveAsync();

            return new SuccessInfo();
        }
    }
}
