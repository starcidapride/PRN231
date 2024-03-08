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
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            //create user
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
            //show user
            CreateMap<User, UserResponseDto>();
            //edit user
            CreateMap<EditUserDto,User>();
            CreateMap<User, EditUserDto>();
            

        }
    }
}
