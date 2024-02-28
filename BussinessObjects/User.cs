using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    [Table("User")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        
        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string? Username { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Password { get; set;  }

        [Required]
        public DateTime Birthdate { get; set; }
    }
}
