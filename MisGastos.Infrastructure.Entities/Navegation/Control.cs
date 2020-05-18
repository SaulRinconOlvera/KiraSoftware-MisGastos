using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.EntityBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Infrastructure.Entities.Navegation
{
    public class Control : BaseCatalog<int>
    {
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public bool HasActionValidation { get; set; }

        [Required]
        public bool HasSpecialActionValidation { get; set; }

        public virtual ICollection<SpecialAction> SpecialActions { get; set; }
        public virtual ICollection<RoleControl> RoleControls { get; set; }
    }
}
