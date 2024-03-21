using AutoMapper;
using BlogFest.Application.Abstract;
using BlogFest.Domain.Administration;
using BlogFest.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Application.Services.Administration.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Result<SuccessInfo,Error>>
    {
        private readonly IUserContext _userContext;
        private readonly IManagerRepository _managerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditUserCommandHandler(IUserContext userContext, IManagerRepository managerRepository, IUnitOfWork unitOfWork)
        {
            _userContext = userContext;
            _managerRepository = managerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SuccessInfo, Error>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.CurrentUserId;

            var userSetting = request.UserSettings;

            var manager = await _managerRepository.GetManagerByIdAsync(userId);

            manager.EditUserSettings(userSetting);

            await _managerRepository.Update(manager);
            await _unitOfWork.SaveAsync();
            return new SuccessInfo();
        }
    }
}
