using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ABAPAI.Domain.Commands.Address
{
    public class CreateAddressCommand : Notifiable, ICommand
    {
        public CreateAddressCommand()
        {
        }

        public CreateAddressCommand(string address_name, string city, string postal_code, string state, int? number)
        {
            Address_name = address_name;
            City = city;
            Postal_code = postal_code;
            State = state;
            Number = number;
        }

        public string Address_name { get; set; }
        public string City { get; set; }
        public string Postal_code { get; set; }
        public string State { get; set; }
        public int? Number { get; set; }

        public void Validate()
        {
            string status = "É obrigatório.";

            AddNotifications(
                 new Contract()
                 .Requires()
                 .IsNotNullOrEmpty(Address_name, "address", status)
                 .IsNotNullOrEmpty(City, "title", status)
                 .IsNotNullOrEmpty(Postal_code, "postal_code", status)
                 .IsNotNullOrEmpty(State, "state", status)
                 .IsNotNull(Number, "number", status)
                 .HasMaxLen(State, 3, "state", "Máximo 3 caracteres. Exemplo: PR")
                 );

        }
    }
}
