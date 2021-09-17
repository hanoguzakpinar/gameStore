using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;

namespace WebApi.Application.PublisherOperations.Queries.GetPublishersQuery
{
    public class GetPublishersQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetPublishersQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetPublishersModel> Handle()
        {
            var _devs = _context.Publishers.OrderBy(x => x.Id).ToList<Publisher>();
            List<GetPublishersModel> _list = _mapper.Map<List<GetPublishersModel>>(_devs);
            return _list;
        }
    }

    public class GetPublishersModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}