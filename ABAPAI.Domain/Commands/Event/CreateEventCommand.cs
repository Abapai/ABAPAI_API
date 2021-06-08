using ABAPAI.Domain.Commands.Address;
using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace ABAPAI.Domain.Commands.Event
{
    public class CreateEventCommand : Notifiable, ICommand
    {
        public CreateEventCommand()
        {
        }

        public CreateEventCommand(string image, string title, string description, DateTime? dateTimeStart, DateTime? dateTimeEnd, int? eventCategory, int? valueEvent, bool? publicLimit, double? price, int? quantity, bool emitQrCode, int? dDD, string phone, string name_url, string uRL, CreateAddressCommand address)
        {
            Image = image;
            Title = title;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            EventCategory = eventCategory;
            ValueEvent = valueEvent;
            PublicLimit = publicLimit;
            Price = price;
            Quantity = quantity;
            EmitQrCode = emitQrCode;
            DDD = dDD;
            Phone = phone;
            Name_url = name_url;
            URL = uRL;
            Address = address;
        }

        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }

        public int? EventCategory { get; set; }
        public int? ValueEvent { get; set; }
        public bool? PublicLimit { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public bool EmitQrCode { get; set; }


        public int? DDD { get; set; }
        public string Phone { get; set; }

        public string Name_url { get; set; }
        public string URL { get; set; }

        public CreateAddressCommand Address { get; set; }

        public string Id_user { get; private set; }
        public void UpdateId(string id)
        {
            this.Id_user = id;
        }


        public void Validate()
        {
            var status = "É obrigatório.";
            AddNotifications(
                 new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(Image, "image", status)
                 .IsNotNullOrEmpty(Title, "title", status)
                 .IsNotNullOrEmpty(Description, "description", status)
                 .IsNotNull(DateTimeStart, "datetimestart", status)
                 .IsNotNull(DateTimeEnd, "datetimeend", status)
                 .IsNotNull(EventCategory, "eventcategory", status)
                 .IsNotNull(ValueEvent, "valueevent", status)
                 .IsNotNull(PublicLimit, "publiclimit", status)
                 .IsNotNull(DDD, "ddd", status)
                 .IsNotNullOrEmpty(Phone, "phone", status)
                 .IsNotNullOrEmpty(Address.ToString(), "address", status)
                 );
        }
    }
}
