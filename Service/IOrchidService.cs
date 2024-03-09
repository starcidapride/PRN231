using BussinessObjects;
using Service.Model.Request;
using Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrchidService
    {
        public IEnumerable<OrchidResponseDto> GetAll();
        public OrchidResponseDto? GetOrchidById(Guid id);
        public OrchidResponseDto? GetOrchidByName(string name);
        public OrchidRequestDto? AddOrchid(OrchidRequestDto orchidRequestDto);
        public void RemoveOrchid(Guid id);
        public EditOrchidDto? UpdateOrchid(EditOrchidDto orchid);
    }
}
