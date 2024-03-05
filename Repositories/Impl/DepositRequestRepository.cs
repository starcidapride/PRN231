using BussinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class DepositRequestRepository : IDepositRequestRepository
    {
        public DepositRequest? AddDepositRequest(DepositRequest depositRequest)=>DepositRequestDAO.Instance.AddDepositRequest(depositRequest);  

        public IEnumerable<DepositRequest> GetAll()=>DepositRequestDAO.Instance.GetAll();   

        public DepositRequest? GetDepositRequestById(Guid id)=>DepositRequestDAO.Instance.GetDepositRequestById(id);

        public void RemoveDepositRequest(DepositRequest depositRequest)=>DepositRequestDAO.Instance.RemoveDepositRequest(depositRequest);

        public DepositRequest? UpdateDepositRequest(DepositRequest depositRequest)=>DepositRequestDAO.Instance.UpdateDepositRequest(depositRequest);
      
    }
}
