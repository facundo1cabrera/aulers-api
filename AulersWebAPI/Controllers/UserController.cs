using AulersWebAPI.DTOs;
using AulersWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulersWebAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //need to work on the Authorization System
        [HttpPost, Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDTO userCreationDTO)
        {
            return Ok();
        }

        [HttpPost, Route("confirm")]
        public async Task<IActionResult> ConfirmUserEmail([FromBody] UserCreationDTO userCreationDTO)
        {
            return Ok();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            return Ok();
        }

        [HttpPost, Route("cart")]
        public async Task<IActionResult> AddItemToCart([FromBody] int userId, int itemId)
        {
            var succeded = await _userService.AddItemInCart(userId, itemId);

            if(succeded == false) { return BadRequest(); }

            return Ok();
        }

        [HttpPost, Route("purchase")]
        public async Task<IActionResult> Purchase()
        {
            //we have to define what will be the placeholder when the purchase has been completed successfully
            return Ok();
        }
    }
}
