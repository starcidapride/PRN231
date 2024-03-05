using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    [Table("deposit_request")]
    public class DepositRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("depositRequestId")]
        public Guid DepositRequestId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set;}
        
        //
        [Column("ownerId")]
        public Guid UserId { get; set; }

        [Column("orchidId")]
        public Guid OrchidId { get; set; }

        //one to many 
        public User User { get; set; }
        public Orchid Orchid { get; set; }



    }
}
