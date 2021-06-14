using ABAPAI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.DTO
{
    public class DTOEventListSimple
    {
        public DTOEventListSimple(Guid id, string image, string title, EventCategory category, DateTime dateStart,ValueEvent valueEvent,bool publicLimit,int quantity,int confirmedQuantity)
        {
            Id = id;
            Image = image;
            this.title = title;
            this.category = category.ToString();
            this.dateStart = dateStart;
            this.valueEvent = valueEvent.ToString();
            this.publicLimit = publicLimit;
            this.quantity = quantity;
            this.confirmedQuantity = confirmedQuantity;
        }

        public Guid Id { get; set; }
        public string Image { get; set; }
        public string title { get; set; }
        public string category { get; set; }

        public string valueEvent { get; set; }
        public DateTime dateStart { get; set; }
        
        public int quantity { get; set; }
        public int confirmedQuantity { get; set; }

        public bool publicLimit { get; set; }



    }
}
