using AulersWebAPI.DTOs;
using AulersWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulersWebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ItemController: ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            var itemDTO = await _itemService.GetItem(id);

            if(itemDTO == null) { return NotFound(); }

            return Ok(itemDTO);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ItemDisplayDTO>>> GetDisplayList([FromQuery] int quantity = 50)
        {
            return await _itemService.GetItemList(quantity);
        }    

    }
}
