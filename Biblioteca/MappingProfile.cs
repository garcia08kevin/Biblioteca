using AutoMapper;
using Biblioteca.DTO;
using Biblioteca.Models;

namespace Biblioteca
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, UserLogin>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
