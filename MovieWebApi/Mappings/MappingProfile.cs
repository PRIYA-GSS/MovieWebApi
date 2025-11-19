using AutoMapper;
using dto = Models.DTOs;
using entity = DataAccess.Entities;
namespace MovieWebApi.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<entity.Movie, dto.Movie>().ReverseMap();
        }
    }
}
