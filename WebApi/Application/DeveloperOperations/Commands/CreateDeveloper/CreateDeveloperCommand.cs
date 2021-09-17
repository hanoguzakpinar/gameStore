using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System;
using WebApi.Entities;

namespace WebApi.Application.DeveloperOperations.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDeveloperModel Model { get; set; }
        public CreateDeveloperCommand(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _developer = _context.Developers.SingleOrDefault(x => x.Name == Model.Name && x.Country == Model.Country);
            if (_developer is not null)
                throw new InvalidOperationException("Developer mevcut.");

            _developer = _mapper.Map<Developer>(Model);

            _context.Developers.Add(_developer);
            _context.SaveChanges();
        }
    }
    public class CreateDeveloperModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}