using ABAPAI.Domain.Utils;
using System;

namespace ABAPAI.Domain.Entities
{
    public class AddressTemplate
    {
        public AddressTemplate(string address, string city, string postal_code, string country, int? number, Guid id_user)
        {
            Address = address;
            City = city;
            Postal_code = postal_code;
            Country = country;
            Number = number;
            Id_address = Guid.NewGuid();
            Id_user = id_user;

        }

        public Guid Id_address { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Postal_code { get; private set; }
        public string Country { get; private set; }
        public int? Number { get; private set; }

        public void UpdateAddress(AddressTemplate template)
        {
            if (template.Address.IsValid())
            {
                this.Address = template.Address;
            }
            if (template.City.IsValid())
            {
                this.City = template.City;
            }
            if (template.Postal_code.IsValid())
            {
                this.Postal_code = template.Postal_code;
            }
            if (template.Country.IsValid())
            {
                this.Country = template.Country;
            }
            if (template.Number.IsValid())
            {
                this.Number = template.Number;
            }
        }

        public Guid Id_user { get; private set; }
        public virtual Staff Staff { get; private set; }

    }
}
