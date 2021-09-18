using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.GameOperations.Commands.DeleteGame
{
    public class DeleteGameCommand
    {
        private readonly IGameStoreDbContext _context;
        public int gameID { get; set; }
        public DeleteGameCommand(IGameStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _game = _context.Games.SingleOrDefault(x => x.Id == gameID);
            if (_game is null)
                throw new InvalidOperationException("Game bulunamadı.");

            var _order = _context.Orders.FirstOrDefault(x => x.GameID == gameID);
            if (_order is not null)
                throw new InvalidOperationException("Game silinemez. Siparişi Var.");

            _context.Games.Remove(_game);
            _context.SaveChanges();
        }
    }
}