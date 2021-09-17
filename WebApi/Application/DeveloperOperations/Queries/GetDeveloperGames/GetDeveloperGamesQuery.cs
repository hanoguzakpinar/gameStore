using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DeveloperOperations.Queries.GetDeveloperGamesQuery
{
    public class GetDeveloperGamesQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public int devID { get; set; }
        public GetDeveloperGamesQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDevGamesModel> Handle()
        {
            var _games = _context.Games.Include(x => x.Developer).Include(x => x.Genre).Include(y => y.Publisher).Where(x => x.DeveloperID == devID).ToList<Game>();

            List<GetDevGamesModel> mv = _mapper.Map<List<GetDevGamesModel>>(_games);
            return mv;
        }
    }
    public class GetDevGamesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public float Price { get; set; }

    }
}