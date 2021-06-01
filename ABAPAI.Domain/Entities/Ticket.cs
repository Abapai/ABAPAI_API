using System;

namespace ABAPAI.Domain.Entities
{
    public class Ticket : Entity
    {

        public Ticket(Guid id_eventFK, Guid id_fanFK, string qrCode, bool payment)
        {
            Id_eventFK = id_eventFK;
            Id_fanFK = id_fanFK;
            QrCode = qrCode;
            Payment = payment;
            Date = DateTime.Now;
        }



        public Guid Id_eventFK { get; private set; }
        public virtual Event Event { get; private set; }

        public Guid Id_fanFK { get; private set; }
        public virtual Fan Fan { get; private set; }

        public string QrCode { get; private set; }

        public bool Payment { get; private set; }
        public DateTime Date { get; private set; }


        public void BuySucess()
        {
            this.Payment = true;
        }




    }
}
