using ABAPAI.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ABAPAI.Domain.Entities
{
    public class Event : Entity
    {
        public Event(string image, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd, EventCategory eventCategory, ValueEvent valueEvent, double price, bool publicLimit, int? quantity, int dDD, string phone, string name_url, string uRL, bool emitQrCode, Guid staff_ForeignKey)
        {
            Image = image;
            Title = title;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            EventCategory = eventCategory;
            ValueEvent = valueEvent;
            Price = price;
            PublicLimit = publicLimit;
            Quantity = quantity;
            DDD = dDD;
            Phone = phone;
            Name_url = name_url;
            URL = uRL;
            EmitQrCode = emitQrCode;
            Staff_ForeignKey = staff_ForeignKey;
        }

        public Event(string image, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd, EventCategory eventCategory, ValueEvent valueEvent, double price, bool publicLimit, int quantity, int dDD, string phone, string name_url, string uRL, bool emitQrCode, string staff_ForeignKey)
        {
            Image = image;
            Title = title;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            EventCategory = eventCategory;
            ValueEvent = valueEvent;
            Price = price;
            PublicLimit = publicLimit;
            Quantity = quantity;
            DDD = dDD;
            Phone = phone;
            Name_url = name_url;
            URL = uRL;
            EmitQrCode = emitQrCode;
            Staff_ForeignKey = Guid.Parse(staff_ForeignKey);
        }

        public string Image { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DateTimeStart { get; private set; }
        public DateTime DateTimeEnd { get; private set; }
        public EventCategory EventCategory { get; private set; }
        public ValueEvent ValueEvent { get; private set; }
        public double Price { get; private set; }
        public bool PublicLimit { get; private set; }
        public int? Quantity { get; private set; }
        public int DDD { get; private set; }
        public string Phone { get; private set; }
        public string Name_url { get; private set; }
        public string URL { get; private set; }
        public bool EmitQrCode { get; private set; }


        #region relation EF
        public Guid Staff_ForeignKey { get; set; }
        public virtual Staff staff { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public virtual AddressTemplate Address { get; set; }
        #endregion
    }
}
