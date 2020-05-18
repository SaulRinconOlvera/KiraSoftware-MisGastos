using MisGastos.Infrastructure.Entities.Navegation;
using MisGastos.Infrastructure.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Infrastructure.Entities.Identity
{
    public class RoleControl : BaseAuditable<int> 
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int ControlId { get; set; }

        public bool ApplyActionValidations { get; set; }
        public bool ApplySpecialActionValidations { get; set; }
        public int LevelAccess { get; set; }

        [StringLength(512)]
        public string SpecialActionsValues { get; set; }

        public virtual Role Role { get; set; }
        public virtual Control Control { get; set; }
    }
}
