using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.Application.PublisherOperations.Commands.DeletePublisher
{
    public class DeletePublisherCommand
    {
        private readonly IGameStoreDbContext _context;
        public int pubID { get; set; }
        public DeletePublisherCommand(IGameStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Publisher = _context.Publishers.SingleOrDefault(x => x.Id == pubID);
            if (_Publisher is null)
                throw new InvalidOperationException("Publisher bulunamadı.");

            var _game = _context.Games.FirstOrDefault(x => x.PublisherID == pubID);
            if (_game is not null)
                throw new InvalidOperationException("Publisher silinemez. Mevcut Oyunu Var.");

            _context.Publishers.Remove(_Publisher);
            _context.SaveChanges();
        }
    }
}