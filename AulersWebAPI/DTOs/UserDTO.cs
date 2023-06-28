using AulersWebAPI.Models;

namespace AulersWebAPI.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<UserItemInCart> UserItemPreselected { get; set; }
    }
}
