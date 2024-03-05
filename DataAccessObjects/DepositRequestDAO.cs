using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class DepositRequestDAO
    {
        private static DepositRequestDAO instance;
        private static readonly object locker = new();
        private readonly CiAuctionContext _context;

        private DepositRequestDAO()
        {
            _context = new CiAuctionContext();
        }

        public static DepositRequestDAO Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new DepositRequestDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<DepositRequest> GetAll()
        {
            try
            {
                return _context.DepositRequests.Include(d=>d.User).Include(d=>d.Orchid).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DepositRequest? GetDepositRequestById(Guid id)
        {
            try
            {
                return _context.DepositRequests.Include(d => d.User).Include(d => d.Orchid)
                    .SingleOrDefault(d => d.DepositRequestId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DepositRequest? AddDepositRequest(DepositRequest depositRequest)
        {
            try
            {
                _context.DepositRequests.Add(depositRequest);
                _context.SaveChanges();
                return depositRequest;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveDepositRequest(DepositRequest depositRequest)
        {
            try
            {
                var existedDepositRequest = GetDepositRequestById(depositRequest.DepositRequestId);
                if (existedDepositRequest != null)
                {
                    _context.DepositRequests.Remove(depositRequest);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DepositRequest? UpdateDepositRequest(DepositRequest depositRequest)
        {
            try
            {
                _context.Entry<DepositRequest>(depositRequest).State = EntityState.Modified;
                _context.SaveChanges();
                return depositRequest;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
