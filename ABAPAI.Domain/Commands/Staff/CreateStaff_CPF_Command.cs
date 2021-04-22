using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Commands.Staff
{
    public class CreateStaff_CPF_Command : Notifiable, ICommand
    {
        public CreateStaff_CPF_Command()
        {
        }

        public CreateStaff_CPF_Command(string email, string name_user, string name, string password, string confirmpassword, string cPF)
        {
            this.email = email;
            this.name_user = name_user;
            this.name = name;
            this.password = password;
            this.confirmpassword = confirmpassword;
            CPF = cPF;
        }

        public string email { get; set; }
        public string name_user { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }

        public string CPF { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(email,"email","E-mail inválido.")                
                .HasLen(CPF,14,"CPF","CPF Inválido.")
                .IsNotNull(name,"Name","Name não pode estar nulo.")
                .IsNotNull(name_user,"Name_user","Name não pode estar nulo.")
                .AreEquals(password,confirmpassword,"Password","Password deve ser igual a Confirmpassword.")
                .IsNotNull(password,"Password","Password não pode estar nulo.")
                .IsNotNull(password, "Confirmpassword", "Confirmpassword não pode estar nulo.")
                );
        }
    }
}
