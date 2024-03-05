using BussinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impl
{
    public class OrchidRepository : IOrchidRepository
    {
        public Orchid? AddOrchid(Orchid orchid) => OrchidDAO.Instance.AddOrchid(orchid);

        public IEnumerable<Orchid> GetAll() => OrchidDAO.Instance.GetAll();

        public Orchid? GetOrchidById(Guid id) => OrchidDAO.Instance.GetOrchidById(id);

        public void RemoveOrchid(Guid id) => OrchidDAO.Instance.RemoveOrchid(id);

        public Orchid UpdateOrchid(Orchid orchid) => OrchidDAO.Instance.UpdateOrchid(orchid);

    }
}
