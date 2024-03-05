using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class OrchidDAO
    {
        private static OrchidDAO instance;
        private static readonly object locker = new();

        private readonly CiAuctionContext _context;
        private OrchidDAO()
        {
            _context = new CiAuctionContext();
        }
        public static OrchidDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new OrchidDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Orchid> GetAll()
        {
            try
            {
                return _context.Orchids.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Orchid? GetOrchidById(Guid id)
        {
            try
            {
                return _context.Orchids.SingleOrDefault(o => o.OrchidId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Orchid? AddOrchid(Orchid orchid)
        {
            try
            {
                _context.Orchids.Add(orchid);
                _context.SaveChanges();
                return orchid;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
