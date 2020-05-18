using MisGastos.Infrastructure.EntityBase;
using System.Collections.Generic;

namespace MisGastos.Infrastructure.Entities.Ubication
{
    public class Country : BaseCatalog<int>
    {
        public IEnumerable<State> States { get; set; }
    }
}
