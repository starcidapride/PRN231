using AutoMapper;
using BussinessObjects;
using Repositories;
using Service.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public RegisterDto AddUser(RegisterDto registerDto)
        {
            User user= mapper.Map<User>(registerDto);
            if (user != null) {
                userRepository.AddUser(user);
            }
            return registerDto;
        }

        public User Login(string email, string password)
        {
           return userRepository.Login(email, password);
        }
    }
}
