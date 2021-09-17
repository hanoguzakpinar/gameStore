using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.PublisherOperations.Commands.UpdatePublisher
{
    public class UpdatePublisherCommand
    {
        private readonly IGameStoreDbContext _context;
        public UpdatePublisherModel Model { get; set; }
        public int pubID { get; set; }
        public UpdatePublisherCommand(IGameStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var _Publisher = _context.Publishers.SingleOrDefault(x => x.Id == pubID);
            if (_Publisher is null)
                throw new InvalidOperationException("Publisher bulunamadı.");

            if (_context.Publishers.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Country.ToLower() == Model.Country.ToLower() && x.Id != pubID))
                throw new InvalidOperationException("Publisher mevcut.");

            _Publisher.Name = _Publisher.Name != default ? _Publisher.Name = Model.Name : _Publisher.Name;
            _Publisher.Country = _Publisher.Country != default ? _Publisher.Country = Model.Country : _Publisher.Country;

            _context.SaveChanges();
        }
    }
    public class UpdatePublisherModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}