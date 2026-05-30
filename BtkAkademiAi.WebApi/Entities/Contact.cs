namespace BtkAkademiAi.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactAdress { get; set; }
        public string ContactMessage { get; set; }
        public string ContactMapLocation { get; set; }
    }
}
