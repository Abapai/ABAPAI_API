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
        IHandler<CreateStaff_CPF_Command>
    {
        private IStaffRepository _staffRepository;

        public StaffHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public ICommandResult Handle(CreateStaff_CPF_Command command)
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



            var staff = new Staff(
                command.name_user,
                command.name,
                command.email,
                command.password,
                Roles.FAN,
                command.CPF,
                null,
                0,
                false);
            
            staff.hashPassword();


            _staffRepository.Create(staff);

            return new GenericCommandResult(
                    true,
                    "Staff criado com sucesso!",
                    new { identificador = staff.Id}
                    );
        }

        
    }
}
