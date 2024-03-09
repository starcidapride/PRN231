using BussinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Request
{
    public class OrchidRequestDto
    {
        public string? ImageUrl { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public DepositedStatus? DepositedStatus { get; set; }
    }
}
