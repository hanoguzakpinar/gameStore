using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;

namespace WebApi.Application.PublisherOperations.Queries.GetPublisherDetail
{
    public class GetPublisherDetailQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public int pubID { get; set; }
        public GetPublisherDetailQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetPublisherDetailModel Handle()
        {
            var _Publisher = _context.Publishers.SingleOrDefault(x => x.Id == pubID);
            if (_Publisher is null)
                throw new InvalidOperationException("Publisher bulunamadı.");

            GetPublisherDetailModel _model = _mapper.Map<GetPublisherDetailModel>(_Publisher);
            return _model;
        }
    }

    public class GetPublisherDetailModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}