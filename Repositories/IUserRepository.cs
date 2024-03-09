using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        public User Login(string email, string password);
        public User AddUser(User user);
        public User GetUserById(Guid id);
        public IEnumerable<User> GetAll();
        public User? UpdateUser(User user);
        public User ActiveUser(Guid id, Boolean active);
        public User? GetUserByUsername(string username);
        public User? GetUserByEmail(string email);   
    }
}
