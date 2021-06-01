using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ABAPAI.Domain.Commands.Staff
{
    public class UpdateStaffCommand : Notifiable, ICommand
    {
        public UpdateStaffCommand() { }

        public UpdateStaffCommand(string name, string name_user, string description, string dDD, string phone, string address, string city, string postal_code, string state, int? number)
        {
            Name = name;
            Name_user = name_user;
            Description = description;
            DDD = dDD;
            Phone = phone;
            Address = address;
            City = city;
            Postal_code = postal_code;
            State = state;
            Number = number;
        }

        public string Id { get; private set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Name_user { get; set; }
        public string Description { get; set; }

        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_code { get; set; }
        public string State { get; set; }
        public int? Number { get; set; }

        public void UpdateId(string id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
               .Requires()
               .IsNotNullOrEmpty(Name, "name", "Deve ser obrigatório.")
               .IsNotNullOrEmpty(Name_user, "name_user", "Deve ser obrigatório.")
            );
        }
    }
}
