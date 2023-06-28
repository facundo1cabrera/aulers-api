namespace AulersWebAPI.Models
{
    public class UserItemInCart
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
