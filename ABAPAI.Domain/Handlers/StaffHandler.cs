using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Commands;
using ABAPAI.Domain.Interfaces.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using Flunt.Notifications;

namespace ABAPAI.Domain.Handlers
{
    public class StaffHandler : Notifiable,
        IHandler<CreateStaff_CPF_Command>,
        IHandler<CreateStaff_CNPJ_Command>,
        IHandler<AuthenticationStaffCommand>,
        IHandler<UpdateStaffCommand>
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

            bool existUserName = _staffRepository.ExistName_user(command.name_user, command.email, command.CPF);
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
                Roles.STAFF,
                command.CPF,
                null,
                null,
                false);

            staff.hashPassword();


            _staffRepository.Create(staff);

            return new GenericCommandResult(
                    true,
                    $"Staff {staff.Name} criado com sucesso!",
                    new { identificador = staff.Id }
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

            bool existUserName = _staffRepository.ExistName_user(command.name_user, command.email, command.CNPJ);
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
                Roles.STAFF,
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

            command.Password = command.Password.GetHash();
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

        public ICommandResult Handle(UpdateStaffCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Staff não está valido!", command.Notifications);

            var staff = _staffRepository.GetById(command.Id);

            var existName_user = _staffRepository.ExistName_userById(command.Id, command.Name_user);

            if (existName_user)
            {
                command.AddNotification("Name_user", "Já existe usuário com este campo");
                return new GenericCommandResult(
                    false,
                    "Staff não atualizado.",
                    command.Notifications
                    );
            }

            var addressTemplate = new AddressTemplate(command.Address, command.City, command.Postal_code, command.Country, command.Number, staff.Id);
            staff.Address.UpdateAddress(addressTemplate);

            staff.UpdateStaff(command.Name_user, command.Name, command.DDD, command.Phone, command.Description, command.DDD, command.Phone);

            _staffRepository.Update(staff);

            return new GenericCommandResult(true, "Staff salvo.", staff);
        }
    }

}