using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Base
{
    public class BaseCatalogViewModel : BaseViewModel
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }

        [StringLength(20)]
        public virtual string ShortName { get; set; }
    }
}
