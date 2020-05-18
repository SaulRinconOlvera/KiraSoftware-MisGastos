using MisGastos.Infrastructure.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Infrastructure.Entities.Navegation
{
    public class SpecialAction : BaseCatalog<int>
    {
        [Required]
        public int ControlId { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(10)]
        public string Value { get; set; }

        public virtual Control Control { get; set; }
    }
}
