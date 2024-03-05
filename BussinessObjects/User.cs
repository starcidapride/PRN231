﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObjects
{
    [Table("user")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userId")]
        public Guid UserId { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("password")]
        public string Password { get; set;  }

        [StringLength(50)]
        [Column("firstName")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("lastName")]
        public string LastName { get; set; }

        [StringLength(64)]
        [Column("walletAddress")]
        public string? WalletAddress { get; set; }

        [StringLength(50)]
        [Column("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [StringLength(50)]
        [Column("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("status")]
        public Boolean Status { get; set; }

        [Required]
        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Orchid> Orchids { get; set; }
        [JsonIgnore]
        public virtual ICollection<DepositRequest> DepositRequests { get; set; }
    }
}
