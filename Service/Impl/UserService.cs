using AutoMapper;
using BussinessObjects;
using Repositories;
using Service.Model.Request;
using Service.Model.Response;
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
            User user = mapper.Map<User>(registerDto);
            user.Status = true;
            user.CreatedAt = DateTime.Now;
            if (user != null)
            {
               var createdUser= userRepository.AddUser(user);
               registerDto= mapper.Map<RegisterDto>(createdUser);
            }
            return registerDto;
        }

        public User DeleteUser(Guid id)
        {
           return userRepository.RemoveUser(id);
        }

        public EditUserDto EditUser(EditUserDto editUserDto)
        {
            User user= mapper.Map<User>(editUserDto);
            user.UpdatedAt = DateTime.Now;
            if(user != null)
            {
                var updatedUser= userRepository.UpdateUser(user);
                editUserDto= mapper.Map<EditUserDto>(updatedUser);  
            }
            return editUserDto;
        }

        public User Login(string email, string password)
        {
            return userRepository.Login(email, password);
        }
    }
}
