using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GameOperations.Commands.UpdateGame
{
    public class UpdateGameCommand
    {
        public UpdateGameModel Model { get; set; }
        public int gameID { get; set; }
        private readonly IGameStoreDbContext _context;
        public UpdateGameCommand(IGameStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var _status = _context.Games.SingleOrDefault(x => x.Id == gameID);
            if (_status is null)
                throw new InvalidOperationException("Game bulunamadı.");

            _status.GenreID = _status.GenreID != default ? Model.GenreID : _status.GenreID;
            _status.Price = _status.Price != default ? Model.Price : _status.Price;
            _status.ReleaseDate = _status.ReleaseDate != default ? Model.ReleaseDate : _status.ReleaseDate;
            _status.Name = _status.Name != default ? Model.Name : _status.Name;
            _status.DeveloperID = _status.DeveloperID != default ? Model.DeveloperID : _status.DeveloperID;
            _status.PublisherID = _status.PublisherID != default ? Model.PublisherID : _status.PublisherID;

            _context.Games.Update(_status);

            _context.SaveChanges();
        }
    }

    public class UpdateGameModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DeveloperID { get; set; }
        public int PublisherID { get; set; }
        public float Price { get; set; }
    }
}