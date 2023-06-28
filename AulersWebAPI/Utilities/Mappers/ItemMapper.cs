using AulersWebAPI.DTOs;
using AulersWebAPI.Models;

namespace AulersWebAPI.Utilities.Mappers
{
    public static class ItemMapper
    {
        public static Item MapFromItemCreationDTOToItem(this ItemCreationDTO itemCreationDTO)
        {
            //needs to add the code to pass the IFormFile to a string when saving the photo
            var item = new Item()
            {
                Name = itemCreationDTO.Name,
                Brand = itemCreationDTO.Brand,
                Description = itemCreationDTO.Description,
                Material = itemCreationDTO.Material,
                Color = itemCreationDTO.Color,
                Size = itemCreationDTO.Size,
                Measurements = itemCreationDTO.Measurements,
                PriceInPesos = itemCreationDTO.PriceInPesos,
                PublicationDate = itemCreationDTO.PublicationDate,
                UserSeller = new User() { Id = itemCreationDTO.UserId }
            };

            return item;
        }

        public static ItemDTO MapFromItemToItemDTO(this Item item)
        {
            var itemDTO = new ItemDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Description = item.Description,
                Image = item.Image,
                Material = item.Material,
                Color = item.Color,
                Size = item.Size,
                Measurements = item.Measurements,
                PriceInPesos = item.PriceInPesos,
                PublicationDate = item.PublicationDate,
                UserSeller = item.UserSeller,
                UserItemInCart = item.UserItemInCart,
                UserItemInCartQuantity = item.UserItemInCart.Count()
            };

            return itemDTO;
        }

        public static ItemDisplayDTO MapFromItemToItemDisplayDTO(this Item item)
        {
            var itemDisplayDTO = new ItemDisplayDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Image = item.Image,
                PriceInPesos = item.PriceInPesos
            };

            return itemDisplayDTO;
        }
    }
}
