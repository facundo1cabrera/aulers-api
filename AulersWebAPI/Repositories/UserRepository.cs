using AulersWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AulersWebAPI.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserItemInCart> AddItemInCart(int userId, int itemId)
        {
            var userItemInCart = new UserItemInCart
            {
                UserId = userId,
                ItemId = itemId
            };

            _applicationDbContext.Add(userItemInCart);
            await _applicationDbContext.SaveChangesAsync();

            return userItemInCart;
        }

        public async Task<User> CreateUser(User user)
        {
            _applicationDbContext.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }
        public async Task DeleteUser(int userId)
        {
            _applicationDbContext.Users.Remove(new User() { Id = userId });
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<User> UpdateUser(int userId, User user)
        {
            user.Id = userId;
            _applicationDbContext.Entry(user).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }
    }
}
