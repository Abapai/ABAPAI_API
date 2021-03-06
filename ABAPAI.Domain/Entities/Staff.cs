using ABAPAI.Domain.Enums;
using ABAPAI.Domain.Utils;
using System.Collections.Generic;

namespace ABAPAI.Domain.Entities
{
    public class Staff : Entity
    {
        #region Contructor

        //Create
        public Staff(string name_user, string name, string email, string password, Roles role, string cPF, string cNPJ, string stateRegistration, bool free)
        {
            Name_user = name_user;
            Name = name;
            Email = email.ToLower();
            Password = password;
            Role = role;
            CPF = cPF;
            CNPJ = cNPJ;
            StateRegistration = stateRegistration;
            Free = free;
            Address = new AddressTemplate(Id);
        }

        //ALL
        public Staff(string name_user, string name, string email, string password, Roles role, string cPF, string cNPJ, string stateRegistration, bool? free, string description, string dDD, string phone, string image)
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

        public string StateRegistration { get; private set; }

        public bool? Free { get; private set; }

        #endregion

        #region Not Require
        public string Description { get; private set; }

        public string DDD { get; private set; }

        public string Phone { get; private set; }

        public string Image { get; private set; }

        public virtual List<Event> Events { get; set; }

        #endregion

        #endregion
        public virtual AddressTemplate Address { get; set; }

        #region Methods

        public void hashPassword()
        {
            this.Password = this.Password.GetHash();
        }

        public void resetPassword(string password)
        {
            this.Password = password;

        }

        public void changeImage(string image)
        {
            this.Image = image;
        }

        public void UpdateStaff(string name, string name_user, string description, string ddd, string phone, string image)
        {
            if (name_user != null)
                this.Name_user = name_user;

            if (name != null)
                this.Name = name;

            if (description != null)
                this.Description = description;

            if (ddd != null)
                this.DDD = ddd;

            if (phone != null)
                this.Phone = phone;
            if (image != null)
                this.Image = image;
        }

        #endregion


    }
}
