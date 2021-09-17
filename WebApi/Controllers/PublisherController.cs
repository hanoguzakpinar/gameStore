using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.PublisherOperations.Commands.CreatePublisher;
using WebApi.Application.PublisherOperations.Commands.DeletePublisher;
using WebApi.Application.PublisherOperations.Commands.UpdatePublisher;
using WebApi.Application.PublisherOperations.Queries.GetPublisherDetail;
using WebApi.Application.PublisherOperations.Queries.GetPublisherGamesQuery;
using WebApi.Application.PublisherOperations.Queries.GetPublishersQuery;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class PublisherController : ControllerBase
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public PublisherController(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            GetPublishersQuery query = new GetPublishersQuery(_context, _mapper);
            var _Publishers = query.Handle();
            return Ok(_Publishers);
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherDetail(int id)
        {
            GetPublisherDetailQuery query = new GetPublisherDetailQuery(_context, _mapper);
            query.pubID = id;

            GetPublisherDetailQueryValidator validator = new GetPublisherDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var _Publisher = query.Handle();
            return Ok(_Publisher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            DeletePublisherCommand query = new DeletePublisherCommand(_context);
            query.pubID = id;

            DeletePublisherCommandValidator validator = new DeletePublisherCommandValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePublisher([FromBody] CreatePublisherModel _Publisher)
        {
            CreatePublisherCommand command = new CreatePublisherCommand(_context, _mapper);
            command.Model = _Publisher;

            CreatePublisherCommandValidator validator = new CreatePublisherCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] UpdatePublisherModel _Publisher)
        {
            UpdatePublisherCommand command = new UpdatePublisherCommand(_context);
            command.Model = _Publisher;
            command.pubID = id;

            UpdatePublisherCommandValidator validator = new UpdatePublisherCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpGet("Publishergames/{id}")]
        public IActionResult GetPublisherGames(int id)
        {
            GetPublisherGamesQuery query = new GetPublisherGamesQuery(_context, _mapper);
            query.pubID = id;

            GetPublisherGamesQueryValidator validator = new GetPublisherGamesQueryValidator();
            validator.ValidateAndThrow(query);

            var _Publishergames = query.Handle();
            return Ok(_Publishergames);
        }
    }
}