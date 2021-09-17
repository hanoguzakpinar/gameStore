using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.PublisherOperations.Queries.GetPublisherGamesQuery
{
    public class GetPublisherGamesQuery
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public int pubID { get; set; }
        public GetPublisherGamesQuery(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetPublisherGamesModel> Handle()
        {
            var _games = _context.Games.Include(x => x.Publisher).Include(x => x.Genre).Include(y => y.Developer).Where(x => x.PublisherID == pubID).ToList<Game>();

            List<GetPublisherGamesModel> mv = _mapper.Map<List<GetPublisherGamesModel>>(_games);
            return mv;
        }
    }
    public class GetPublisherGamesModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public float Price { get; set; }

    }
}