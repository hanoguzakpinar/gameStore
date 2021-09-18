using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GameOperations.Queries.GetGamesQuery
{
    public class GetGamesQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGamesQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGamesModel> Handle()
        {
            var _gameList = _context.Games
                   .Include(x => x.Publisher)
                    .Include(x => x.Genre)
                     .Include(y => y.Developer)
                      .OrderBy(z => z.Id)
                      .ToList();

            List<GetGamesModel> mv = _mapper.Map<List<GetGamesModel>>(_gameList);
            return mv;
        }
    }
    public class GetGamesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public float Price { get; set; }
    }
}