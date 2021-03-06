using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IGameStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var _genres = query.Handle();
            return Ok(_genres);
        }
    }
}