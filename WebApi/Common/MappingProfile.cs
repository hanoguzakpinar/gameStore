using AutoMapper;
using WebApi.Application.DeveloperOperations.Commands.CreateDeveloper;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperDetail;
using WebApi.Application.DeveloperOperations.Queries.GetDeveloperGamesQuery;
using WebApi.Application.DeveloperOperations.Queries.GetDevelopersQuery;
using WebApi.Application.GenreOperations.Queries.GetGenres;
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
        }
    }
}