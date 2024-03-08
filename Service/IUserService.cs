using BussinessObjects;
using Service.Model.Request;
using Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        public User Login(string email, string password);
        public RegisterDto AddUser(RegisterDto registerDto);
        public UserResponseDto GetUserById(Guid id);
        public List<UserResponseDto> GetAllUser();

        public EditUserDto EditUser(EditUserDto editUserDto);
        public UserResponseDto DeleteUser(Guid id);
        
    }
}
