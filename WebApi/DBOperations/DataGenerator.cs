using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<GameStoreDbContext>>()))
            {
                List<Genre> genres = new List<Genre>(){
                    new Genre { Name = "FPS" },
                    new Genre { Name = "Racing" },
                    new Genre { Name = "Sports" },
                    new Genre { Name = "RPG" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Simulator" },
                    new Genre { Name = "Action" }
                };

                List<Developer> developers = new List<Developer>(){
                    new Developer {Name="Playground Games", Country="United Kingdom"},
                    new Developer {Name="Ubisoft Montreal", Country="Canada"},
                    new Developer {Name="Ubisoft Toronto",Country="Canada"},
                    new Developer {Name="Rocksteady Studios",Country="United Kingdom"},
                    new Developer {Name="Monolith Productions",Country="United States"},
                    new Developer {Name="EA Sports",Country="United States"}
                };

                List<Publisher> publishers = new List<Publisher>(){
                    new Publisher{Name="Ubisoft",Country="France"},
                    new Publisher{Name="Warner Bros",Country="United States"},
                    new Publisher{Name="Microsoft",Country="United States"},
                    new Publisher{Name="Electronic Arts",Country="United States"}
                };

                List<Game> games = new List<Game>(){
                    new Game{Name="Forza Horizon 4",ReleaseDate=DateTime.Now.AddYears(-3),GenreID=2,PublisherID=3,Price=30,DeveloperID=1},
                    new Game{Name="FIFA",ReleaseDate=DateTime.Now.AddYears(-1),GenreID=3,PublisherID=4,Price=60,DeveloperID=6},
                    new Game{Name="Batman: Arkham Knight",ReleaseDate=DateTime.Now.AddYears(-6),GenreID=4,PublisherID=2,Price=20,DeveloperID=4},
                    new Game{Name="Middle-earth: Shadow of War",ReleaseDate=DateTime.Now.AddYears(-4),GenreID=7,PublisherID=2,Price=10,DeveloperID=5},
                    new Game{Name="Assassin's Creed Odyssey",ReleaseDate=DateTime.Now.AddYears(-3),GenreID=4,PublisherID=1,Price=10,DeveloperID=2},
                    new Game{Name="Tom Clancy's Splinter Cell: Blacklist",ReleaseDate=DateTime.Now.AddYears(-7),GenreID=4,PublisherID=1,Price=15,DeveloperID=3},
                };

                List<Customer> customers = new List<Customer>(){
                    new Customer{Name="Oğuzhan",Surname="Akpınar",Email="oguzhanakpinar@yahoo.com",Password="535353"},
                    new Customer{Name="Oğuz",Surname="Han",Email="oguzhan@yahoo.com",Password="343434"},
                    new Customer{Name="Kullanıcı",Surname="Üç",Email="deneme@yahoo.com",Password="111111"},
                };

                List<Order> orders = new List<Order>(){
                    new Order{CustomerID=1,GameID=1,OrderDate=DateTime.Now.AddMonths(-1),Price=games[0].Price},
                    new Order{CustomerID=1,GameID=2,OrderDate=DateTime.Now.AddMonths(-2),Price=games[1].Price},
                    new Order{CustomerID=2,GameID=3,OrderDate=DateTime.Now.AddMonths(-3),Price=games[2].Price},
                    new Order{CustomerID=2,GameID=4,OrderDate=DateTime.Now.AddMonths(-3),Price=games[3].Price},
                    new Order{CustomerID=3,GameID=5,OrderDate=DateTime.Now.AddMonths(-3),Price=games[4].Price},
                    new Order{CustomerID=3,GameID=6,OrderDate=DateTime.Now.AddMonths(-3),Price=games[5].Price},
                };

                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(genres);

                if (context.Developers.Any())
                {
                    return;
                }
                context.Developers.AddRange(developers);

                if (context.Publishers.Any())
                {
                    return;
                }
                context.Publishers.AddRange(publishers);

                if (context.Games.Any())
                {
                    return;
                }
                context.Games.AddRange(games);

                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(customers);

                if (context.Orders.Any())
                {
                    return;
                }
                context.Orders.AddRange(orders);

                context.SaveChanges();
            }
        }
    }
}