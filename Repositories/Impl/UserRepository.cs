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

        public IEnumerable<User> GetAll()=>UserDAO.Instance.GetAll();

        public User GetUserById(Guid id)=>UserDAO.Instance.GetUserById(id);

        public User Login(string email, string password)=>UserDAO.Instance.Login(email, password);

        public User RemoveUser(Guid id)=>UserDAO.Instance.RemoveUser(id);

        public User? UpdateUser(User user)=>UserDAO.Instance.UpdateUser(user);

       
    }
}
