using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class GameStoreDbContext : DbContext, IGameStoreDbContext
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        { }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}