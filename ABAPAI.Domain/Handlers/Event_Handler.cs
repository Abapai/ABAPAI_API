using ABAPAI.Domain.Commands;
using ABAPAI.Domain.Commands.Event;
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Interfaces.Commands;
using ABAPAI.Domain.Interfaces.Handlers;
using ABAPAI.Domain.Interfaces.Repositories;
using ABAPAI.Domain.Utils;
using Flunt.Notifications;
using System;
using System.Threading.Tasks;

namespace ABAPAI.Domain.Handlers
{
    public class Event_Handler : Notifiable,
        IHandler<CreateEventCommand>
    {
        private readonly IFileUpload _fileUpload;
        private readonly IEventRepository _eventRepository;

        public Event_Handler(IFileUpload fileUpload, IEventRepository eventRepository)
        {
            _fileUpload = fileUpload;
            _eventRepository = eventRepository;
        }

        public async Task<ICommandResult> Handle(CreateEventCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Evento não está valido!", command.Notifications);

            if (Enum.IsDefined(typeof(EventCategory), command.EventCategory) is false)
            {
                return new GenericCommandResult(false, "Eventcategory é inválido", command.Notifications);
            }

            if (Enum.IsDefined(typeof(ValueEvent), command.ValueEvent) is false)
            {
                return new GenericCommandResult(false, "ValueEvent é inválido", command.Notifications);
            }


            if (command.Quantity <= 0 && command.PublicLimit.Value)
            {
                return new GenericCommandResult(false, "Quantity deve ter uma quantidade, porque o publicLimit está ativado", command.Notifications);
            }
            
            if((ValueEvent)command.ValueEvent == ValueEvent.Monetizado && command.Price <= 0)
            {
                return new GenericCommandResult(false, "ValueEvent é Monetizado e o valor esta menor ou igual a 0", command.Notifications);
            }

            if ((DateTime.Now.Date < command.DateTimeStart || command.DateTimeEnd > command.DateTimeStart) is false)
            {
                return new GenericCommandResult(false, "Data inválida", command.Notifications);
            }

            if (command.Image.IsBase64String() is false)
            {
                return new GenericCommandResult(false, "Image deve ser base64", command.Notifications);
            }

            var id_image = await _fileUpload.UploadBase64ImageAsync(command.Image);



            var @event = new Event(id_image,
                                   command.Title,
                                   command.Description,
                                   command.DateTimeStart.Value,
                                   command.DateTimeEnd.Value,
                                   (EventCategory)command.EventCategory.Value,
                                   (ValueEvent)command.ValueEvent.Value,
                                   0,
                                   command.PublicLimit.Value,
                                   command.Quantity.Value,
                                   command.DDD.Value,
                                   command.Phone,
                                   command.Name_url,
                                   command.URL,
                                   true,
                                   Guid.Parse(command.Id_user)
                                   );

            var id_event = _eventRepository.Create(@event);

            return new GenericCommandResult(true, $"Evento criado com sucesso. ID: {id_event}.");

        }
    }
}
