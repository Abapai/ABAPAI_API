using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Commands.Event
{
    public class UpdateEventCommand : Notifiable, ICommand
    {
        public UpdateEventCommand() { }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
