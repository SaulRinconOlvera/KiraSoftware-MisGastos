using MisGastos.Infrastructure.EntityBase.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Infrastructure.EntityBase
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
