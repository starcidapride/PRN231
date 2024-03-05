using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDepositRequestRepository
    {
        public IEnumerable<DepositRequest> GetAll();
        public DepositRequest? GetDepositRequestById(Guid id);
        public DepositRequest? AddDepositRequest(DepositRequest depositRequest);
        public void RemoveDepositRequest(DepositRequest depositRequest);
        public DepositRequest? UpdateDepositRequest(DepositRequest depositRequest);
    }
}
