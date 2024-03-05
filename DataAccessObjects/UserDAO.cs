using BussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private static UserDAO instance = default!;
        private static readonly object locker = new();

        private readonly CiAuctionContext _context;
        private UserDAO()
        {
            _context = new CiAuctionContext();
        }

        public static UserDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public User? Login(string email, string password)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.Email.Equals(email));

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        return user;
                    }

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User AddUser(User user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserById(Guid id)
        {
            try
            {
                return _context.Users.SingleOrDefault(u => u.UserId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User? UpdateUser(User user)
        {
            try
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var existedUser = GetUserById(id);
                _context.Users.Remove(existedUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
