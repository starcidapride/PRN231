using AutoMapper;
using BussinessObjects;
using Service.Model.Request;
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

            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
