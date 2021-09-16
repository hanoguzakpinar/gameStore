using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IGameStoreDbContext
    {
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Developer> Developers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}