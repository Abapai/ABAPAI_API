using System;

namespace ABAPAI.Domain.Entities
{
    public class Ticket : Entity
    {

        public Ticket(Guid id_eventFK, Guid? id_fanFK, string qrCode, bool payment,string cpf)
        {
            Id_eventFK = id_eventFK;
            Id_fanFK = id_fanFK;
            QrCode = qrCode;
            Payment = payment;
            Date = DateTime.Now;
            Cpf = cpf;
        }



        public Guid Id_eventFK { get; private set; }
        public virtual Event Event { get; private set; }

        public Guid? Id_fanFK { get; private set; }  //Retirar esse ? depois do trabalho de experiência criativa
        public virtual Fan Fan { get; private set; }

        public string QrCode { get; private set; }

        public bool Payment { get; private set; }
        public DateTime Date { get; private set; }

        public string Cpf { get; private set; }//Retirar esse ? depois do trabalho de experiência criativa


        public void BuySucess()
        {
            this.Payment = true;
        }




    }
}
