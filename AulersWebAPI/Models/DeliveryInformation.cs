namespace AulersWebAPI.Models
{
    public class DeliveryInformation
    {
        //not working for the first version 
        public User User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string FloorOrDepartmentNumber { get; set; }
        public string AdditionalNotes { get; set; }
        public string PhoneNumber { get; set; }

    }
}
