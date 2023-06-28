using AulersWebAPI.DTOs;
using AulersWebAPI.Repositories;
using AulersWebAPI.Utilities.Mappers;

namespace AulersWebAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IFileSavingService _imageSavingService;
        private readonly string container = "ItemImages";

        public ItemService(IItemRepository itemRepository, IFileSavingService imageSavingService)
        {
            _itemRepository = itemRepository;
            _imageSavingService = imageSavingService;
        }
        public async Task<ItemDTO> CreateItem(ItemCreationDTO itemCreationDTO)
        {
            var item = itemCreationDTO.MapFromItemCreationDTOToItem();

            if (itemCreationDTO.Image == null) { return null; }
            
            //needs to be changed when impl
            using (var memoryStream = new MemoryStream())
            {
                await itemCreationDTO.Image.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(itemCreationDTO.Image.FileName);
                item.Image = await _imageSavingService.SaveFile(content, extension, container,
                    itemCreationDTO.Image.ContentType);
            }

            await _itemRepository.CreateItem(item);
            
            var itemDTO = item.MapFromItemToItemDTO();

            return itemDTO;

        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var itemExists = await _itemRepository.GetItemById(itemId);

            if (itemExists == null) { return false; }

            await _itemRepository.DeleteItem(itemId);

            return true;
        }

        public async Task<ItemDTO> GetItem(int itemId)
        {
            var item = await _itemRepository.GetItemById(itemId);

            if(item == null) { return null; }

            var itemDTO = item.MapFromItemToItemDTO();

            return itemDTO;
        }

        public async Task<ItemDTO> UpdateItem(int itemId, ItemCreationDTO itemCreationDTO)
        {

            var itemExists = await _itemRepository.GetItemById(itemId);

            if(itemExists == null) { return null; }

            var item = itemCreationDTO.MapFromItemCreationDTOToItem();

            if (itemCreationDTO.Image == null) { return null; }

            using (var memoryStream = new MemoryStream())
            {
                await itemCreationDTO.Image.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(itemCreationDTO.Image.FileName);
                item.Image = await _imageSavingService.SaveFile(content, extension, container,
                    itemCreationDTO.Image.ContentType);
            }

            await _itemRepository.UpdateItem(itemId, item);

            var itemDTO = item.MapFromItemToItemDTO();

            return itemDTO;
        }
        public async Task<List<ItemDisplayDTO>> GetItemList(int itemQuantity)
        {
            var itemCount = await _itemRepository.GetItemCount();

            Random random = new Random();

            var skipper = random.Next(0, itemCount);

            var remainingElements = itemCount - skipper;

            if (remainingElements - itemQuantity <= 0) { skipper = 0; }

            var itemList = await _itemRepository.GetItemList(skipper, itemQuantity);

            var itemDisplayDTOList = new List<ItemDisplayDTO>();

            foreach(var item in itemList)
            {
                itemDisplayDTOList.Add(item.MapFromItemToItemDisplayDTO());
            }

            return itemDisplayDTOList;
        }
    }
}
