using Microsoft.AspNetCore.Identity;
using MisGastos.Infrastructure.EntityBase.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisGastos.Infrastructure.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>, IBaseEntity<int>, IBaseAuditable
    {
        public RoleClaim() : base()
        { Enabled = true; }

        [Key]
        public override int Id { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastModificationDate { get; set; }

        [StringLength(50)]
        public string DeletedBy { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DeletionDate { get; set; }
        public  bool Enabled { get; set; }
        public virtual Role Role { get; set; }
    }
}
