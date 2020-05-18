using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Ubication.Interfaces;
using MisGastos.Web.Services.Controllers.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisGastos.Web.Services.Areas.Ubication.Controllers
{
    public class CountryController : BaseAuthenticatedController<CountryViewModel>,
        IBaseController<CountryViewModel>
    {
        public CountryController(ICountryDomainService service) 
            : base(service) { }

        [HttpGet("WithStates")]
        public async Task<IEnumerable<CountryViewModel>> GetWhitStatesAsync() =>
           await _service.GetAllAsync(new string[] { "States" });
    }
}