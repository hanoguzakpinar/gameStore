using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DeveloperOperations.Commands.CreateDeveloper;
using WebApi.Application.DeveloperOperations.Commands.DeleteDeveloper;
using WebApi.Application.DeveloperOperations.Commands.UpdateDeveloper;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperDetail;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperGamesQuery;
using WebApi.Application.DeveloperOperations.Queries.GetDevelopersQuery;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class DeveloperController : ControllerBase
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeveloperController(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDevelopers()
        {
            GetDevelopersQuery query = new GetDevelopersQuery(_context, _mapper);
            var _developers = query.Handle();
            return Ok(_developers);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeveloperDetail(int id)
        {
            GetDeveloperDetailQuery query = new GetDeveloperDetailQuery(_context, _mapper);
            query.devID = id;

            GetDeveloperDetailQueryValidator validator = new GetDeveloperDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _developer = query.Handle();
            return Ok(_developer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            DeleteDeveloperCommand query = new DeleteDeveloperCommand(_context);
            query.devID = id;

            DeleteDeveloperCommandValidator validator = new DeleteDeveloperCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDeveloper([FromBody] CreateDeveloperModel _developer)
        {
            CreateDeveloperCommand command = new CreateDeveloperCommand(_context, _mapper);
            command.Model = _developer;

            CreateDeveloperCommandValidator validator = new CreateDeveloperCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDeveloper(int id, [FromBody] UpdateDeveloperModel _developer)
        {
            UpdateDeveloperCommand command = new UpdateDeveloperCommand(_context);
            command.Model = _developer;
            command.devID = id;

            UpdateDeveloperCommandValidator validator = new UpdateDeveloperCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpGet("Developergames/{id}")]
        public IActionResult GetDeveloperGames(int id)
        {
            GetDeveloperGamesQuery query = new GetDeveloperGamesQuery(_context, _mapper);
            query.devID = id;

            GetDeveloperGamesQueryValidator validator = new GetDeveloperGamesQueryValidator();
            validator.ValidateAndThrow(query);

            var _developergames = query.Handle();
            return Ok(_developergames);
        }
    }
}