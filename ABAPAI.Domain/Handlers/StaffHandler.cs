using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Commands;
using ABAPAI.Domain.Interfaces.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Handlers
{
    public class StaffHandler : Notifiable,
        IHandler<CreateStaffCommand>
    {
        private IStaffRepository _staffRepository;

        public StaffHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public ICommandResult Handle(CreateStaffCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Staff não criada, operação inválida",
                    command.Notifications
                    );
            }

            var staff = new Staff(command.name_user,command.name,command.email,command.password,Roles.FAN,command.CPF,null,0,false);

            var id = _staffRepository.Create(staff);

            return new GenericCommandResult(
                    true,
                    "Staff criado com sucesso!"                  
                    );
        }

        
    }
}
