using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Web.Services.Controllers.Base;

namespace MisGastos.Web.Services.Areas.Authorization.Controllers
{
    public class UserRoleController : BaseAuthenticatedController<UserRoleViewModel>,
        IBaseController<UserRoleViewModel>
    {
        public UserRoleController(IUserRoleDomainService service)
            : base(service) { }
    }
}