using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IGameStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model { get; set; }
        public CreateOrderCommand(IGameStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var _game = _context.Games.SingleOrDefault(x => x.Id == Model.GameID);
            if (_game is null)
                throw new InvalidOperationException("Game mevcut değil.");
            var _customer = _context.Customers.SingleOrDefault(x => x.Id == Model.CustomerID);
            if (_customer is null)
                throw new InvalidOperationException("Customer mevcut değil.");

            var _order = _mapper.Map<Order>(Model);

            _context.Orders.Add(_order);
            _context.SaveChanges();
        }
    }
    public class CreateOrderModel
    {
        public DateTime OrderDate { get; set; }
        public int GameID { get; set; }
        public int CustomerID { get; set; }
        public float Price { get; set; }
    }
}