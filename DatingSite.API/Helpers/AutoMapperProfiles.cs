using AutoMapper;
using DatingSite.API.Models;
using DatingSite.API.Dtos;
using System.Linq;

namespace DatingSite.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsersForListDto>().ForMember(dest => dest.PhotoUrl, opt => { 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest=> dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });
            CreateMap<User, UserForDetailedDto>().ForMember(dest => dest.PhotoUrl, opt => { 
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest=> dest.Age, opt => {
                opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
            });
        }
    }
}