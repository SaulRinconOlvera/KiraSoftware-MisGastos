using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Web.Services.Controllers.Base;

namespace MisGastos.Web.Services.Areas.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserClaimController : 
        BaseAuthenticatedController<UserClaimViewModel>, 
        IBaseController<UserClaimViewModel>
    {
        public UserClaimController(IUserClaimDomainService service) 
            : base(service) { }

        [AllowAnonymous]
        public override Task<ActionResult> Post([FromBody] UserClaimViewModel viewModel)
        {
            return base.Post(viewModel);
        }
    }
}