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
using System.Threading.Tasks;

namespace ABAPAI.Domain.Handlers
{
    public class StaffHandler : Notifiable,
        IHandler<CreateStaff_CPF_Command>,
        IHandler<CreateStaff_CNPJ_Command>,
        IHandler<AuthenticationStaffCommand>
    {
        private IStaffRepository _staffRepository;

        public StaffHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public  ICommandResult Handle(CreateStaff_CPF_Command command)
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

            bool existUserName = _staffRepository.ExistName_user(command.name_user,command.email,command.CPF);
            if (existUserName)
            {
                command.AddNotification("Name_user ou Email ou CNPJ", "Já existe usuário com este campo");
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
                null,
                false);
            
            staff.hashPassword();


             _staffRepository.Create(staff);

            return new GenericCommandResult(
                    true,
                    $"Staff {staff.Name} criado com sucesso!",
                    new { identificador = staff.Id}
                    );
        }

        public ICommandResult Handle(CreateStaff_CNPJ_Command command)
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

            bool existUserName = _staffRepository.ExistName_user(command.name_user,command.email,command.CNPJ);
            if (existUserName)
            {
                command.AddNotification("Name_user ou Email ou CNPJ", "Já existe usuário com este campo");
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
                null,
                command.CNPJ,
                command.StateRegistration,
                command.Free,
                null,
                null,
                null,
                null
                );

            staff.hashPassword();

            _staffRepository.Create(staff);

            return new GenericCommandResult(
                    true,
                    $"Staff {staff.Name} criado com sucesso!",
                    new { identificador = staff.Id }
                    );
        }

        public ICommandResult Handle(AuthenticationStaffCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Operação inválida!",
                    command.Notifications
                    );
            }

            Staff staff = _staffRepository.FindStaff(command.Email, command.Password);

            if (staff is null)
            {
                return new GenericCommandResult(
                    false,
                    "Email ou senha inválido(s)!",
                    null
                    );
            }

            var token = Utils.Utils.GetJWTStaff(staff.Id.ToString(), staff.Role);

            return new GenericCommandResult(
                true,
                "Autenticação feita com sucesso.",
                token
                );

        }
    }

}
