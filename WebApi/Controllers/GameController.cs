using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GameOperations.Commands.CreateGame;
using WebApi.Application.GameOperations.Commands.DeleteGame;
using WebApi.Application.GameOperations.Commands.UpdateGame;
using WebApi.Application.GameOperations.Queries.GetGameDetail;
using WebApi.Application.GameOperations.Queries.GetGamesQuery;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GameController : ControllerBase
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public GameController(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            GetGamesQuery query = new GetGamesQuery(_context, _mapper);
            var _Games = query.Handle();
            return Ok(_Games);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameDetail(int id)
        {
            GetGameDetailQuery query = new GetGameDetailQuery(_context, _mapper);
            query.gameID = id;

            GetGameDetailQueryValidator validator = new GetGameDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _Game = query.Handle();
            return Ok(_Game);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            DeleteGameCommand query = new DeleteGameCommand(_context);
            query.gameID = id;

            DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] CreateGameModel _Game)
        {
            CreateGameCommand command = new CreateGameCommand(_context, _mapper);
            command.Model = _Game;

            CreateGameCommandValidator validator = new CreateGameCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] UpdateGameModel _update)
        {
            UpdateGameCommand updt = new UpdateGameCommand(_context);
            updt.Model = _update;
            updt.gameID = id;
            
            UpdateGameCommandValidator validator = new UpdateGameCommandValidator();
            validator.ValidateAndThrow(updt);
            updt.Handle();

            return Ok();
        }
    }
}
