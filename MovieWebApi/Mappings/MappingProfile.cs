using AutoMapper;
using entity=DataAccess.Entities;
using dto=Models.DTOs;
using System.Linq;
namespace MovieWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<entity.Movie, dto.Movie>()
                .ReverseMap();

            CreateMap<entity.Movie, dto.Movie>()
                .ForMember(dest => dest.TheatreIds, opt => opt.MapFrom(src => src.Theatres.Select(t => t.TheatreId)))
                .ForMember(dest => dest.BookingIds, opt => opt.MapFrom(src => src.Bookings.Select(b => b.BookingId)))
                .ReverseMap()
                .ForMember(dest => dest.Theatres, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());


            CreateMap<entity.Theatre, dto.Theatre>()
                .ForMember(dest => dest.MovieIds, opt => opt.MapFrom(src => src.Movies.Select(m => m.Id)))
                .ForMember(dest => dest.BookingIds, opt => opt.MapFrom(src => src.Bookings.Select(b => b.BookingId)))
                .ReverseMap()
                .ForMember(dest => dest.Movies, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());

            CreateMap<entity.User, dto.User>()
                .ForMember(dest => dest.BookingIds, opt => opt.MapFrom(src => src.Bookings.Select(b => b.BookingId)))
                .ReverseMap()
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());

            CreateMap<entity.Booking, dto.Booking>().ReverseMap();
        }
    }
}