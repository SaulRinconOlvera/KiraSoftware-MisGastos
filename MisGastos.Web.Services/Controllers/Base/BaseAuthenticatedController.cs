using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MisGastos.Domain.Model.Base;
using MisGastos.Domain.Services.Base;
using MisGastos.Web.Services.Utilities.Configuration;

namespace MisGastos.Web.Services.Controllers.Base
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = AppConfiguration.GeneralAccessPolicyName)]
    public class BaseAuthenticatedController<TViewModel> : BaseController<TViewModel>
        where TViewModel : class, IBaseViewModel<int>
    {
        public BaseAuthenticatedController(IDomainServiceBase<int, TViewModel> service) : base(service)
        {
        }
    }
}
