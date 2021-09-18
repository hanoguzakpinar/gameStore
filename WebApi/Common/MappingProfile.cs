using AutoMapper;
using WebApi.Application.CustomerOperations.CreateCustomer;
using WebApi.Application.CustomerOperations.GetOrders;
using WebApi.Application.DeveloperOperations.Commands.CreateDeveloper;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperDetail;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperGamesQuery;
using WebApi.Application.DeveloperOperations.Queries.GetDevelopersQuery;
using WebApi.Application.GameOperations.Commands.CreateGame;
using WebApi.Application.GameOperations.Queries.GetGameDetail;
using WebApi.Application.GameOperations.Queries.GetGamesQuery;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.PublisherOperations.Commands.CreatePublisher;
using WebApi.Application.PublisherOperations.Queries.GetPublisherDetail;
using WebApi.Application.PublisherOperations.Queries.GetPublisherGamesQuery;
using WebApi.Application.PublisherOperations.Queries.GetPublishersQuery;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Developer, GetDevelopersModel>();
            CreateMap<Developer, GetDeveloperDetailModel>();
            CreateMap<CreateDeveloperModel, Developer>();
            CreateMap<Game, GetDevGamesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name)).ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));
            CreateMap<Publisher, GetPublishersModel>();
            CreateMap<Publisher, GetPublisherDetailModel>();
            CreateMap<CreatePublisherModel, Publisher>();
            CreateMap<Game, GetPublisherGamesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name)).ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Order, GetOrdersView>().ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game.Name)).ForMember(x => x.Customer, y => y.MapFrom(z => z.Customer.Name + " " + z.Customer.Surname));
            CreateMap<Game, GetGamesModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name)).ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));
            CreateMap<Game, GetGameDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher.Name)).ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));
            CreateMap<CreateGameModel, Game>();
        }
    }
}