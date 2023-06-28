using Microsoft.EntityFrameworkCore;

namespace AulersWebAPI.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserItemInCart>().
                HasKey(userItem => new { userItem.UserId, userItem.ItemId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserItemInCart> UsersItems { get; set; }
    }
}
