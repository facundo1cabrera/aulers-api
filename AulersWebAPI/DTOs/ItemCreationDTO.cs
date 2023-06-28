using AulersWebAPI.Models;

namespace AulersWebAPI.DTOs
{
    public class ItemCreationDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Measurements { get; set; }
        public int PriceInPesos { get; set; }
        public DateTime PublicationDate { get; set; }
        public int UserId { get; set; }
    }
}
