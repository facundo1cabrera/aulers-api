using AulersWebAPI.DTOs;
using AulersWebAPI.Repositories;
using AulersWebAPI.Utilities.Mappers;

namespace AulersWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;

        public UserService(IUserRepository userRepository, IItemRepository itemRepository)
        {
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }
        public async Task<bool> AddItemInCart(int userId, int itemId)
        {
            var user = await _userRepository.GetUserById(userId);
            if(user == null) { return false; }
            var item = await _itemRepository.GetItemById(itemId);
            if(item == null) { return false; }

            await _userRepository.AddItemInCart(userId, itemId);

            return true;
        }

        public async Task<UserDTO> CreateUser(UserCreationDTO userCreationDTO)
        {
            var userExists = _userRepository.GetUserByEmail(userCreationDTO.Email);

            if(userExists != null) { return null; }

            var user = userCreationDTO.MapFromUserCreationDTOToUser();

            await _userRepository.CreateUser(user);

            var userDTO = user.MapFromUserToUserDTO();

            return userDTO;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null) { return false; }

            await _userRepository.DeleteUser(id);

            return true;
        }

        public async Task<UserDTO> UpdateUser(int userId, UserCreationDTO userCreationDTO)
        {
            var userExists = await _userRepository.GetUserById(userId);

            if(userExists == null) { return null; }

            var user = userCreationDTO.MapFromUserCreationDTOToUser();

            await _userRepository.UpdateUser(userId, user);

            var userDTO = user.MapFromUserToUserDTO();

            return userDTO;
        }
    }
}
