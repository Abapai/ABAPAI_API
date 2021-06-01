using System.Collections.Generic;

namespace ABAPAI.Domain.Entities
{
    public class Fan : Entity
    {
        public Fan(string name, string email, string idFirebase, string image, string signInProvider)
        {
            Name = name;
            Email = email;
            IdFirebase = idFirebase;
            Image = image;
            SignInProvider = signInProvider;
        }

        public Fan(string name, string email, string idFirebase, string image, string cPF, string signInProvider) : this(name, email, idFirebase, image, cPF)
        {
            SignInProvider = signInProvider;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string IdFirebase { get; private set; }
        public string Image { get; private set; }
        public string CPF { get; private set; }
        public string SignInProvider { get; private set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
