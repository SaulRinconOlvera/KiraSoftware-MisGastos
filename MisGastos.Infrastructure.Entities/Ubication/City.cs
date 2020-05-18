using MisGastos.Infrastructure.EntityBase;

namespace MisGastos.Infrastructure.Entities.Ubication
{
    public class City : BaseCatalog<int>
    {
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}