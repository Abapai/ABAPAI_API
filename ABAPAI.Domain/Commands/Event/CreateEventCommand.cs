using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace ABAPAI.Domain.Commands.Event
{
    public class CreateEventCommand : Notifiable, ICommand
    {
        public CreateEventCommand(string image, string title, string description, DateTime? dateTimeStart, DateTime? dateTimeEnd, int? eventCategory, int? valueEvent, bool publicLimit, int? quantity, double? price,int? dDD, string phone, string name_url, string uRL)
        {
            Image = image;
            Title = title;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            EventCategory = eventCategory;
            ValueEvent = valueEvent;
            PublicLimit = publicLimit;
            Quantity = quantity;
            Price = price;
            DDD = dDD;
            Phone = phone;
            Name_url = name_url;
            URL = uRL;
        }

        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateTimeStart { get; set; }

        public DateTime? DateTimeEnd { get; set; }

        public int? EventCategory { get; set; }

        public int? ValueEvent { get; set; }
        public bool? PublicLimit { get; set; }
        public double? Price { get; private set; }
        public int? Quantity { get; set; }
        public int? DDD { get; set; }
        public string Phone { get; set; }
        public string Name_url { get; set; }
        public string URL { get; set; }
        public bool EmitQrCode { get; private set; }

        public void UpdateId(string id)
        {
            this.Id_user = id;
        }
        public string Id_user { get; private set; }

        public void Validate()
        {
            AddNotifications(
                 new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(Image, "image", "image inválido.")
                 .IsNotNullOrEmpty(Title, "title", "title é obrigatório")
                 .IsNotNullOrEmpty(Description, "", "Não pode estar nula.")
                 .IsNotNull(DateTimeStart, "datetimestart", "Não pode estar nula.")
                 .IsNotNull(DateTimeEnd, "datetimeend", "Não pode estar nula.")
                 .IsNotNull(EventCategory, "eventcategory", "Não pode estar nula.")
                 .IsNotNull(ValueEvent, "valueevent", "Não pode estar nula.")
                 .IsNotNull(Quantity, "quantity", "Não pode estar nula.")
                 .IsNotNull(PublicLimit, "publiclimit", "Não pode estar nula.")
                 .IsNotNull(DDD, "ddd", "Não pode estar nula.")
                 .IsNotNullOrEmpty(Phone, "phone", "Não pode estar nula.")
                 );

            
        }
    }
}
