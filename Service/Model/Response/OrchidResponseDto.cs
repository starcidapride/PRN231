using BussinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Response
{
    public class OrchidResponseDto
    {
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DepositedStatus DepositedStatus { get; set; }
    }
}
