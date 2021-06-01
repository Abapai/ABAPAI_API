namespace ABAPAI.Domain.DTO
{
    public class DTOStaff_Profile
    {

        public string email { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string name_user { get; set; }
        public string description { get; set; }
        public string ddd { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int? number { get; set; }

        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string stateRegistration { get; set; }
        public bool free { get; set; }
    }
}
