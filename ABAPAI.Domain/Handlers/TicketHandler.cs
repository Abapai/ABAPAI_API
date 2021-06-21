using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Ticket;
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
    public class TicketHandler : Notifiable,
        IHandler<CreateTicketCommand>
    {

        private readonly IEventRepository _eventRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketHandler(IEventRepository eventRepository, ITicketRepository ticketRepository)
        {
            _eventRepository = eventRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<ICommandResult> Handle(CreateTicketCommand command)
        {

            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ticket não está valido!", command.Notifications);

            var @event = await _eventRepository.GetEventById(command.id_event);

            if (@event == null)
            {
                return new GenericCommandResult(false, "Não existe event com esse id", command.Notifications);
            }

            if (@event.PublicLimit && @event.Quantity == @event.QuantityConfirmed)
            {
                return new GenericCommandResult(false, "Ingressos esgotados", command.Notifications);
            }

            var pagament = false;
            if((ValueEvent)@event.ValueEvent == ValueEvent.Gratuito)
            {
                pagament = true;
            }

            var ticket = new Ticket(@event.Id,null,Guid.NewGuid().ToString(), pagament,command.CPF);
            var validationIDFan = _ticketRepository.ExistByIdFan(command.CPF, command.id_event);
            if (validationIDFan)
            {
                command.AddNotification("CPF", "Ingresso já foi emitido");
                return new GenericCommandResult(false, "Usuário já emitiu ingresso", command.Notifications);
            }

            var status = false;
            status = await _ticketRepository.CreateTicketAsync(ticket);

            if(status is false)
            {
                return new GenericCommandResult(false, "Houve algum problema, tente novamente", command.Notifications);
            }


            @event.applyQuantityConfirmed();

            status = await _eventRepository.UpdateEvent(@event);

            if (status is false)
            {
                return new GenericCommandResult(false, "Houve algum problema, tente novamente", command.Notifications);
            }

            return new GenericCommandResult(true, "Emitido com sucesso", new { message = "Ingresso foi enviado para o seu e-mail" });


        }
    }
}
