using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;

namespace WebApi.Application.DeveloperOperations.Queries.GetDevelopersQuery
{
    public class GetDevelopersQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDevelopersQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDevelopersModel> Handle()
        {
            var _devs = _context.Developers.OrderBy(x => x.Id).ToList<Developer>();
            List<GetDevelopersModel> _list = _mapper.Map<List<GetDevelopersModel>>(_devs);
            return _list;
        }
    }

    public class GetDevelopersModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}