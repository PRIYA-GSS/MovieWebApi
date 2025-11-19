using AutoMapper;
using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace MovieWebApi.Mappings
{
    public class MappingProfile: Profile
    {
        
            public MappingProfile()
            {
                CreateMap<entity.Movie, dto.Movie>()
                    .ForMember(dest => dest.Theatres, opt => opt.MapFrom(src => src.Theatres))
                    .ReverseMap();

                CreateMap<entity.Theatre, dto.Theatre>()
                    .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies))
                    .ReverseMap();

                CreateMap<entity.User, dto.User>()
                    .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
                    .ReverseMap();

                CreateMap<entity.Booking, dto.Booking>().ReverseMap();
            }
        

    }
}
