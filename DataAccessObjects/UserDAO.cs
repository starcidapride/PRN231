using BussinessObjects;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private static UserDAO instance = default!;
        private static readonly object locker = new ();

        private readonly CiAuctionContext _context;
        private UserDAO() { 
            _context = new CiAuctionContext();
        }

        public static UserDAO Instance { 
            get { 
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
            try {
                var user = _context.Users.SingleOrDefault(u=>u.Email.Equals(email));
                
                if(user != null) 
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password)){
                        return user;
                    }

                }
                return null;
            }catch (Exception ex)
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


    }
}
