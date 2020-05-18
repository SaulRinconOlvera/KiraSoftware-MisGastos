using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Ubication.Interfaces;
using MisGastos.Web.Services.Controllers.Base;

namespace MisGastos.Web.Services.Areas.Ubication.Controllers
{
    public class CityController : BaseAuthenticatedController<CityViewModel>,
        IBaseController<CityViewModel>
    {
        public CityController(ICityDomainService service)
            : base(service) { }
    }
}