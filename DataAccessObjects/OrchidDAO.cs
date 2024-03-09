using BussinessObjects;
using Microsoft.EntityFrameworkCore;
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
                return _context.Orchids.Include(o => o.User).ToList();
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
                return _context.Orchids.Include(o=>o.User).SingleOrDefault(o => o.OrchidId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Orchid? GetOrchidByName(string name)
        {
            try
            {
                return _context.Orchids.Include(o => o.User).SingleOrDefault(o => o.Name.Equals(name));
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

        public void RemoveOrchid(Guid id)
        {
            try
            {
                var existedOrchid = GetOrchidById(id);
                if (existedOrchid != null)
                {
                    _context.Orchids.Remove(existedOrchid);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Orchid UpdateOrchid(Orchid orchid)
        {
            try
            {
                _context.Entry<Orchid>(orchid).State = EntityState.Modified;
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
