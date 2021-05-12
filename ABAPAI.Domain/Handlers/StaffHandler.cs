using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Staff;
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Commands;
using ABAPAI.Domain.Interfaces.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using Flunt.Notifications;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Handlers
{
    public class StaffHandler : Notifiable,
        IHandler<CreateStaff_CPF_Command>,
        IHandler<CreateStaff_CNPJ_Command>,
        IHandler<AuthenticationStaffCommand>,
        IHandler<UpdateStaffCommand>
    {
        private IStaffRepository _staffRepository;
        private IFileUpload _fileUpload;
        public StaffHandler(IStaffRepository staffRepository, IFileUpload fileUpload)
        {
            _staffRepository = staffRepository;
            _fileUpload = fileUpload;
        }

        public async Task<ICommandResult> Handle(CreateStaff_CPF_Command command)
        {
           return await Task.Run(() =>
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
                staff.Address = new AddressTemplate(staff.Id);
                _staffRepository.Create(staff);

                return new GenericCommandResult(
                        true,
                        $"Staff {staff.Name} criado com sucesso!",
                        new { id = staff.Id }
                        );
            });

            
        }

        public async Task<ICommandResult> Handle(CreateStaff_CNPJ_Command command)
        {
            return await Task.Run(() =>
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
                staff.Address = new AddressTemplate(staff.Id);
                _staffRepository.Create(staff);

                return new GenericCommandResult(
                        true,
                        $"Staff {staff.Name} criado com sucesso!",
                        new { identificador = staff.Id }
                        );
            });
        }

        public async Task<ICommandResult> Handle(AuthenticationStaffCommand command)
        {
            return await Task.Run(() =>
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
                    new {
                        user = new
                        {
                            id = token,
                            name = staff.Name,
                            image = staff.Image.ConvertAddressImageToURLAzureBlob()
                        }
                    }
                    );
            });
        }

        public async Task<ICommandResult> Handle(UpdateStaffCommand command)
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

            
            //Update Image - AZURE STORANGE BLOB
            if (!string.IsNullOrEmpty(command.Image) && command.Image.IsBase64String())
            {

                if (string.IsNullOrEmpty(staff.Image))
                {
                    //Adicionar foto
                    staff.changeImage(await _fileUpload.UploadBase64ImageAsync(command.Image));                    
                }
                else
                {
                    //Atualizar foto
                    bool isImageUpdate = await _fileUpload.UpdateImageAsync(command.Image, staff.Image.Replace("https://abnerdev.blob.core.windows.net/abapai/", ""));
                    if (!isImageUpdate)
                    {
                        command.AddNotification("Image", "Erro ao atualizar a image");
                        return new GenericCommandResult(
                                    false,
                                    "Staff não atualizado.",
                                    command.Notifications
                                );
                    }
                }
                               
            }

            //Update STAFF
            staff.UpdateStaff(command.Name, command.Name_user, command.Description, command.DDD, command.Phone, staff.Image);

            //Update Address
            var addressTemplate = new AddressTemplate(command.Address, command.City, command.Postal_code, command.Country, command.Number, staff.Id);
            staff.Address.UpdateAddress(addressTemplate);

            _staffRepository.Update(staff);

            return new GenericCommandResult(true, "Staff salvo.", new { message="Staff atualizado com sucesso"});
        }
    }

}