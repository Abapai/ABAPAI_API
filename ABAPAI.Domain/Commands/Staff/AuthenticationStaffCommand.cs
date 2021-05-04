using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ABAPAI.Domain.Commands.Staff
{
    public class AuthenticationStaffCommand : Notifiable, ICommand
    {
        public AuthenticationStaffCommand()
        {
        }

        public AuthenticationStaffCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmailOrEmpty(Email, "Email", "E-mail inválido.")
                .IsNotNullOrEmpty(Password, "Password", "Password não pode estar nula.")                
                );
        }
    }

}
