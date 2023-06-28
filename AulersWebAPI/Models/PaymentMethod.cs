namespace AulersWebAPI.Models
{
    public class PaymentMethod
    {
        //Not working for the first version
        public User User { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SecurityCode { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int CardOwnerDNI { get; set; }
    }
}
