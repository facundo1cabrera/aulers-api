namespace AulersWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string EmailVerificationCode { get; set; }
        public bool IsVerificated { get; set; }
        public string Password { get; set; }
        public List<UserItemInCart> UserItemPreselected { get; set; }
    }
}
