using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.GameOperations.Queries.GetGameDetail
{
    public class GetGameDetailQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public int gameID { get; set; }
        public GetGameDetailQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGameDetailModel Handle()
        {
            var _game = _context.Games.Include(x => x.Genre).Include(y => y.Publisher).Include(y => y.Developer).SingleOrDefault(x => x.Id == gameID);
            if (_game is null)
                throw new InvalidOperationException("Game bulunamadı.");

            GetGameDetailModel _model = _mapper.Map<GetGameDetailModel>(_game);
            return _model;
        }
    }

    public class GetGameDetailModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public float Price { get; set; }
    }
}