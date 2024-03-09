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

        public User? GetUserByEmail(string email)=>UserDAO.Instance.GetUserByEmail(email);  

        public User GetUserById(Guid id)=>UserDAO.Instance.GetUserById(id);

        public User? GetUserByUsername(string username)=>UserDAO.Instance.GetUserByUsername(username);

        public User Login(string email, string password)=>UserDAO.Instance.Login(email, password);

        public User ActiveUser(Guid id, Boolean active)=>UserDAO.Instance.ActiveUser(id,active);

        public User? UpdateUser(User user)=>UserDAO.Instance.UpdateUser(user);
    
    }
}
