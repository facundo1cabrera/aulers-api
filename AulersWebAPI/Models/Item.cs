namespace AulersWebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Measurements { get; set; }
        public int PriceInPesos { get; set; }
        public DateTime PublicationDate { get; set; }
        public User UserSeller { get; set; }
        public List<UserItemInCart> UserItemInCart { get; set; }

    }
}
