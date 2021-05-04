using ABAPAI.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ABAPAI.Domain.Commands.Staff
{
    public class UpdateStaffCommand : Notifiable, ICommand
    {
        public UpdateStaffCommand() {}

        public UpdateStaffCommand(string name, string name_user, string description, string ddd, string phone, string email, string password)
        {
            Name = name;
            Name_user = name_user;
            Description = description;
            DDD = ddd;
            Phone = phone;
        }

        public string Id { get; private set; }
        public string Name { get; set; }
        public string Name_user { get; set; }
        public string Description { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Postal_code { get; private set; }
        public string Country { get; private set; }
        public int? Number { get; private set; }

        public void UpdateId (string id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
               .Requires()
               .IsNotNullOrEmpty(Name, "Name", "Name inválido.")
               .IsNotNullOrEmpty(Name_user, "Name_user", "Name_user inválido.")
            );
        }
    }
}
