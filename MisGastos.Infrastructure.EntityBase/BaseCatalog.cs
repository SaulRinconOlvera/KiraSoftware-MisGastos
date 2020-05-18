using System.ComponentModel.DataAnnotations;

namespace MisGastos.Infrastructure.EntityBase
{
    public class BaseCatalog<T> : BaseAuditable<T>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }

        [StringLength(20)]
        public virtual string ShortName { get; set; }
    }
}
