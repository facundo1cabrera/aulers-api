using AulersWebAPI.Models;

namespace AulersWebAPI.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemById(int itemId);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(int itemId, Item item);
        Task DeleteItem(int itemId);
        Task<List<Item>> GetItemList(int itemQuantity, int randomSkipper);
        Task<int> GetItemCount();
    }
}
