using MisGastos.Domain.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Ubication
{
    public class StateViewModel : BaseCatalogViewModel
    {
        [Required]
        public int CountryId { get; set; }
        public CountryViewModel Country { get; set; }
        public IEnumerable<CityViewModel> Cities { get; set; }
    }
}
