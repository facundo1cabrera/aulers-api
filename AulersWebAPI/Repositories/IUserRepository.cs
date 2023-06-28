using AulersWebAPI.Models;

namespace AulersWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<UserItemInCart> AddItemInCart(int userId, int itemId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int userId, User user);
        Task DeleteUser(int userId); 
    }
}
