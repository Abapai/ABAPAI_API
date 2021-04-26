using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Commands.Staff
{
    public class CreateStaff_CNPJ_Command : Notifiable, ICommand
    {

        public CreateStaff_CNPJ_Command()
        {
        }

        public CreateStaff_CNPJ_Command(string email, string name_user, string name, string password, string confirmpassword, string cNPJ, string stateRegistration, bool free)
        {
            this.email = email;
            this.name_user = name_user;
            this.name = name;
            this.password = password;
            this.confirmpassword = confirmpassword;
            CNPJ = cNPJ;
            StateRegistration = stateRegistration;
            Free = free;
        }


        public string email { get; set; }
        public string name_user { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }

        public string CNPJ { get; set; }
        public string StateRegistration { get; set; }
        public bool Free { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmailOrEmpty(email, "email", "E-mail inválido.")
                .HasLen(CNPJ,18, "CNPJ", $"CNPJ Inválido.")
                .IfNotNull(StateRegistration==null?"":null,z=>z.IsTrue(Free,"Free","Se não for ISENTO, é necessário o preenchimento da StateRegistration"))
                .IfNotNull(StateRegistration,x=> x.IsFalse(Free,"Free", "Free tem que estar false, já que contém StateRegistration"))
                .IsNotNull(Free, "Free","Free não pode estar nulo.")
                .IsNotNullOrEmpty(name, "Name", "Name não pode estar nulo.")
                .IsNotNullOrEmpty(name_user, "Name_user", "Name não pode estar nulo.")
                .AreEquals(password, confirmpassword, "Password", "Password deve ser igual a Confirmpassword.")
                .IsNotNullOrEmpty(password, "Password", "Password não pode estar nulo.")
                .IsNotNullOrEmpty(password, "Confirmpassword", "Confirmpassword não pode estar nulo.")
                );
        }
    }
}
