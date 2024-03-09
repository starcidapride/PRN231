using AutoMapper;
using BussinessObjects;
using Service.Model.Request;
using Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // MAPPING USER
            //create user
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
            //show user
            CreateMap<User, UserResponseDto>();
            //edit user
            CreateMap<EditUserDto, User>();
            CreateMap<User, EditUserDto>();

            //MAPPING ORCHID
            //create orchid
            CreateMap<OrchidRequestDto, Orchid>()
                .ForMember(dest => dest.OrchidId, opt => opt.Ignore());
            CreateMap<Orchid, OrchidRequestDto>();
            //show orchid
            CreateMap<Orchid, OrchidResponseDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            //edit orchid
            CreateMap<Orchid, EditOrchidDto>();
            CreateMap<EditOrchidDto, Orchid>();
        }
    }
}
