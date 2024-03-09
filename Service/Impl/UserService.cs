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
            user.UpdatedAt = DateTime.Now;

            if (user != null)
            {
               var createdUser= userRepository.AddUser(user);
               registerDto= mapper.Map<RegisterDto>(createdUser);
            }
            return registerDto;
        }

        public UserResponseDto ActiveUser(Guid id, Boolean active)
        {
           return mapper.Map<UserResponseDto>(userRepository.ActiveUser(id, active));
        }

        public EditUserDto EditUser(EditUserDto editUserDto)
        {
            User updatedUser = userRepository.GetUserByEmail(editUserDto.Email);   
            if(updatedUser != null)
            {
                updatedUser.Status = true;
                updatedUser.UpdatedAt=DateTime.Now;
                //update from dto
                updatedUser.Username = editUserDto.Username;
                updatedUser.Email= editUserDto.Email;
                updatedUser.Birthdate= editUserDto.Birthdate;
                updatedUser.FirstName= editUserDto.FirstName;
                updatedUser.LastName= editUserDto.LastName;
                updatedUser.WalletAddress= editUserDto.WalletAddress;
                //update to database
                var user=userRepository.UpdateUser(updatedUser);
                //map to dto
                editUserDto = mapper.Map<EditUserDto>(user);  
            }
            return editUserDto;
        }

        public List<UserResponseDto> GetAllUser()
        {
            List<User> userList = (List<User>)userRepository.GetAll();
            return mapper.Map<List<UserResponseDto>>(userList);
        }

        public UserResponseDto? GetUserByEmail(string email)
        {
            return mapper.Map<UserResponseDto>(userRepository.GetUserByEmail(email));
        }

        public UserResponseDto GetUserById(Guid id)
        {
            return mapper.Map<UserResponseDto>(userRepository.GetUserById(id));
        }

        public UserResponseDto? GetUserByUsername(string username)
        {
            return mapper.Map<UserResponseDto>(userRepository.GetUserByUsername(username));
        }

        public User Login(string email, string password)
        {
            return userRepository.Login(email, password);
        }
    }
}
