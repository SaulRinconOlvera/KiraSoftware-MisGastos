using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Web.Services.Controllers.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisGastos.Web.Services.Areas.Authorization.Controllers
{
    public class RoleControlController : BaseAuthenticatedController<RoleControlViewModel>,
        IBaseController<RoleControlViewModel>
    {
        public RoleControlController(IRoleControlDomainService service)
            : base(service) { }

        [HttpGet("WithAdditionalData")]
        public async Task<IEnumerable<RoleControlViewModel>> GetWithAdditionalDataAsync() =>
           await _service.GetAllAsync(new string[] { "Role", "Control" });
    }
}
