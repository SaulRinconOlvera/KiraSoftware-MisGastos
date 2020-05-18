using MisGastos.Domain.Model.Base;
using System.Collections.Generic;

namespace MisGastos.Domain.Model.Ubication
{
    public class CountryViewModel : BaseCatalogViewModel
    {
        public IEnumerable<StateViewModel> States { get; set; }
    }
}
