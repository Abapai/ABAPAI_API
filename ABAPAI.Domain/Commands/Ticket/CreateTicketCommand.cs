using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Commands.Ticket
{
    public class CreateTicketCommand : Notifiable, ICommand
    {
        public CreateTicketCommand(string name, string cPF, string email)
        {
            Name = name;
            CPF = cPF;
            Email = email;
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public string id_event { get; private set; }

        public void updateIdEvent(string id)
        {
            id_event = id;
        }
        public void Validate()
        {
            var status = "É obrigatório.";
            AddNotifications(
                 new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(Name, "name", status)
                 .IsNotNullOrEmpty(CPF, "CPF", status)
                 .IsEmailOrEmpty(Email,"email","E-mail está incorreto")
                 .IsNotNullOrEmpty(Email, "email", status)
                 );
        }
    }
}
