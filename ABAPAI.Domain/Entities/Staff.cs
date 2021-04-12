using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Utils;
namespace ABAPAI.Domain.Entities
{
    public class Staff : Entity
    {
        #region Contructor

        //Create
        public Staff(string name_user, string name, string email, string password, string role, string cPF, string cNPJ, int stateRegistration, bool free)
        {
            Name_user = name_user;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CPF = cPF;
            CNPJ = cNPJ;
            StateRegistration = stateRegistration;
            Free = free;
        }

        //ALL
        public Staff(string name_user, string name, string email, string password, string role, string cPF, string cNPJ, int stateRegistration, bool free, string description, int dDD, string phone, string image, string address, string city, string postal_code, string country, int number) : this(name_user, name, email, password, role, cPF, cNPJ, stateRegistration, free)
        {
            Description = description;
            DDD = dDD;
            Phone = phone;
            Image = image;
            Address = address;
            City = city;
            Postal_code = postal_code;
            Country = country;
            Number = number;
        }

        #endregion

        #region Properties

        #region Require
        public string Name_user { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Roles Role { get; private set; }

        public string CPF { get; private set; }

        public string CNPJ { get; private set; }

        public int? StateRegistration { get; private set; }

        public bool? Free { get; private set; }

        #endregion

            #region Not Require
        public string Description { get; private set; }

        public string DDD { get; private set; }

        public string Phone { get; private set; }

        public string Image { get; private set; }                          
        
        public AddressTemplate addressTemplate { get; private set; }

            #endregion

        #endregion

        #region Methods

        public void updateStaff(string name_user,string description,string name,string image, string ddd, string phone, AddressTemplate template)
        {

            if (image.IsValid())
            {
                this.Image = image;
            }
            if (name.IsValid())
            {
                this.Name = name;
            }
            if (name_user.IsValid())
            {
                this.Name_user = name_user;
            }
            if (description.IsValid())
            {
                this.Description = description;
            }            
            if (ddd.IsValid())
            {
                this.DDD = ddd;
            }
            if (phone.IsValid())
            {
                this.Phone = phone;
            }
            if (template.IsValid())
            {
                addressTemplate.UpdateAddress(template);
            }            
            
        }

        public void resetPassword(string password)
        {
             this.Password = password;
           
        }

        public void changeImage(string image)
        {
            this.Image = image;
        }

        #endregion
                

    }
}
