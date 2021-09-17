using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;

namespace WebApi.Application.DeveloperOperations.Queries.GetDeveloperDetail
{
    public class GetDeveloperDetailQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public int devID { get; set; }
        public GetDeveloperDetailQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetDeveloperDetailModel Handle()
        {
            var _developer = _context.Developers.SingleOrDefault(x => x.Id == devID);
            if (_developer is null)
                throw new InvalidOperationException("Developer bulunamadı.");

            GetDeveloperDetailModel _model = _mapper.Map<GetDeveloperDetailModel>(_developer);
            return _model;
        }
    }

    public class GetDeveloperDetailModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}