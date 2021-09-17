using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.PublisherOperations.Commands.CreatePublisher
{
    public class CreatePublisherCommand
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreatePublisherModel Model { get; set; }
        public CreatePublisherCommand(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _Publisher = _context.Publishers.SingleOrDefault(x => x.Name == Model.Name && x.Country == Model.Country);
            if (_Publisher is not null)
                throw new InvalidOperationException("Publisher mevcut.");

            _Publisher = _mapper.Map<Publisher>(Model);

            _context.Publishers.Add(_Publisher);
            _context.SaveChanges();
        }
    }
    public class CreatePublisherModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}