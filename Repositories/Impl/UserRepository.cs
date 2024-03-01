using BussinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)=>UserDAO.Instance.AddUser(user);

        public User Login(string email, string password)=>UserDAO.Instance.Login(email, password);
      
    }
}
