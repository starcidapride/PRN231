using BussinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObjects
{
    [Table("orchid")]
    public class Orchid
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("orchidId")]
        public Guid OrchidId { get; set; }

        [Column("imageUrl")]
        public string? ImageUrl { get; set; }

        [StringLength(200)]
        [Column("name")]
        public string? Name { get; set; }

        [StringLength(1000)]
        [Column("description")]
        public string? Description { get; set; }


        [Column("ownerId")]
        public Guid UserId { get; set; }

        [Column("depositedStatus")]
        public DepositedStatus DepositedStatus { get; set; }

        public User? User { get; set; }

        [JsonIgnore]
        public virtual ICollection<DepositRequest>? DepositRequests { get; set; }
    }
}
