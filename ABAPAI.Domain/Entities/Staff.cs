using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Utils;
namespace ABAPAI.Domain.Entities
{
    public class Staff : Entity
    {
        #region Contructor

        //Create
        public Staff(string name_user, string name, string email, string password, Roles role, string cPF, string cNPJ, int stateRegistration, bool free)
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
        public Staff(string name_user, string name, string email, string password, Roles role, string cPF, string cNPJ, int? stateRegistration, bool? free, string description, string dDD, string phone, string image, AddressTemplate addressTemplate)
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
            Description = description;
            DDD = dDD;
            Phone = phone;
            Image = image;
<<<<<<< Updated upstream
            this.addressTemplate = addressTemplate;
        }      
=======

        }
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
        public void updateStaff(string name_user,string description,string name,string image, string ddd, string phone, AddressTemplate template)
=======
        public void updateStaff(string name_user, string description, string name, string image, string ddd, string phone)
>>>>>>> Stashed changes
        {


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
<<<<<<< Updated upstream
            if (template.IsValid())
            {
                addressTemplate.UpdateAddress(template);
            }            
            
=======

>>>>>>> Stashed changes
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
