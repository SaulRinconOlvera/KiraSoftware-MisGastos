using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Ubication.Interfaces;
using MisGastos.Web.Services.Controllers.Base;

namespace MisGastos.Web.Services.Areas.Ubication.Controllers
{
    public class StateController : BaseAuthenticatedController<StateViewModel>,
        IBaseController<StateViewModel>
    {
        public StateController(IStateDomainService service)
            : base(service) { }
    }
}