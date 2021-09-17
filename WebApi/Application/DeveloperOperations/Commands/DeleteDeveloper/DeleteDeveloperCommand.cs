using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.Application.DeveloperOperations.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommand
    {
        private readonly IGameStoreDbContext _context;
        public int devID { get; set; }
        public DeleteDeveloperCommand(IGameStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _developer = _context.Developers.SingleOrDefault(x => x.Id == devID);
            if (_developer is null)
                throw new InvalidOperationException("Developer bulunamadı.");

            var _game = _context.Games.FirstOrDefault(x => x.DeveloperID == devID);
            if (_game is not null)
                throw new InvalidOperationException("Developer silinemez. Mevcut Oyunu Var.");

            _context.Developers.Remove(_developer);
            _context.SaveChanges();
        }
    }
}