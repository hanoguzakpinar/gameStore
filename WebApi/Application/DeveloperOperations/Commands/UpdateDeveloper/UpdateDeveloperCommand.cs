using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.DeveloperOperations.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommand
    {
        private readonly IGameStoreDbContext _context;
        public UpdateDeveloperModel Model { get; set; }
        public int devID { get; set; }
        public UpdateDeveloperCommand(IGameStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _developer = _context.Developers.SingleOrDefault(x => x.Id == devID);
            if (_developer is null)
                throw new InvalidOperationException("Developer bulunamadı.");

            if (_context.Developers.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Country.ToLower() == Model.Country.ToLower() && x.Id != devID))
                throw new InvalidOperationException("Developer mevcut.");

            _developer.Name = _developer.Name != default ? _developer.Name = Model.Name : _developer.Name;
            _developer.Country = _developer.Country != default ? _developer.Country = Model.Country : _developer.Country;

            _context.SaveChanges();
        }
    }
    public class UpdateDeveloperModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}