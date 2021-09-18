using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.GameOperations.Commands.CreateGame
{
    public class CreateGameCommand
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGameModel Model { get; set; }
        public CreateGameCommand(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _game = _context.Games.SingleOrDefault(x => x.Name == Model.Name);
            if (_game is not null)
                throw new InvalidOperationException("Game mevcut.");

            _game = _mapper.Map<Game>(Model);

            _context.Games.Add(_game);
            _context.SaveChanges();
        }
    }

    public class CreateGameModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DeveloperID { get; set; }
        public int PublisherID { get; set; }
        public float Price { get; set; }
    }
}