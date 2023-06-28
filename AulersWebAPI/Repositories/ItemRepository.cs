using AulersWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AulersWebAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Item> CreateItem(Item item)
        {
            _applicationDbContext.Items.Add(item);
            await _applicationDbContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItem(int itemId)
        {
            _applicationDbContext.Remove(new Item { Id = itemId });
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Item> UpdateItem(int itemId, Item item)
        {
            item.Id = itemId;
            _applicationDbContext.Entry(item).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Item> GetItemById(int itemId)
        {
            var item = await _applicationDbContext.Items.FirstOrDefaultAsync(item => item.Id == itemId);
            return item;
        }
        public async Task<List<Item>> GetItemList(int itemQuantity, int randomSkipper)
        {
            return await _applicationDbContext.Items.OrderBy(item => Guid.NewGuid()).Skip(randomSkipper).Take(itemQuantity).ToListAsync();          
        }

        public async Task<int> GetItemCount()
        {
            return await _applicationDbContext.Items.CountAsync();
        }
    }
}
