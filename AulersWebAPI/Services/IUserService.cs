using AulersWebAPI.DTOs;

namespace AulersWebAPI.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserCreationDTO userCreationDTO);
        Task<bool> AddItemInCart(int userId, int itemId);
        Task<UserDTO> UpdateUser(int userId, UserCreationDTO userCreationDTO);
        Task<bool> DeleteUser(int userId);
    }
}
