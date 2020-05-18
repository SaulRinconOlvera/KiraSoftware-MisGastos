using MisGastos.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Ubication
{
    public class CityViewModel : BaseCatalogViewModel
    {
        [Required]
        public int StateId { get; set; }
        public virtual StateViewModel State { get; set; }
    }
}
