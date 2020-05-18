using MisGastos.Infrastructure.EntityBase;
using System.Collections.Generic;

namespace MisGastos.Infrastructure.Entities.Ubication
{
    public class State : BaseCatalog<int>
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
