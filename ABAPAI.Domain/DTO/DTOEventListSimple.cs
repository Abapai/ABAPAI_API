using System;

namespace ABAPAI.Domain.DTO
{
    public class DTOEventListSimple
    {
        public DTOEventListSimple(Guid id, string image, string title)
        {
            Id = id;
            Image = image;
            this.title = title;
        }

        public Guid Id { get; set; }
        public string Image { get; set; }
        public string title { get; set; }
    }
}
