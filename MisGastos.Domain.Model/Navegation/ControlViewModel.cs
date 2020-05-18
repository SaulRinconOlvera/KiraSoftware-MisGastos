using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Navegation
{
    public class ControlViewModel : BaseCatalogViewModel
    {
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        public bool HasActionValidation { get; set; }

        [Required]
        public bool HasSpecialActionValidation { get; set; }

        public virtual ICollection<RoleControlViewModel> RoleControls { get; set; }
    }
}
