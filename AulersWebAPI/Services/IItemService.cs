using AulersWebAPI.DTOs;

namespace AulersWebAPI.Services
{
    public interface IItemService
    {
        Task<ItemDTO> GetItem(int itemId);
        Task<ItemDTO> CreateItem(ItemCreationDTO itemCreationDTO);
        Task<ItemDTO> UpdateItem(int itemId, ItemCreationDTO itemCreationDTO);
        Task<bool> DeleteItem(int itemId);
        Task<List<ItemDisplayDTO>> GetItemList(int itemQuantity);
    }
}
