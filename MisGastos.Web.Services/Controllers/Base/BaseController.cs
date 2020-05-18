using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Base;
using MisGastos.Domain.Services.Base;

namespace MisGastos.Web.Services.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<TViewModel> : ControllerBase, IBaseController<TViewModel>
        where TViewModel : class, IBaseViewModel<int>
    {
        internal readonly IDomainServiceBase<int, TViewModel> _service;
        internal string AcceptedFileTypes = string.Empty;

        public BaseController(IDomainServiceBase<int, TViewModel> service) =>
            _service = service;

        [HttpGet]
        public virtual async Task<IEnumerable<TViewModel>> Get() =>
            await _service.GetAllAsync();

        [HttpGet("{id}", Name = "Get[controller]")]
        public virtual async Task<TViewModel> Get(int id) =>
            await _service.GetAsync(id);

        [HttpPost]
        public virtual async Task<ActionResult> Post([FromBody] TViewModel viewModel)
        {
            try
            {
                SetServiceUser();
                var value = await _service.AddWithResponseAsync(viewModel);
                return new CreatedAtRouteResult($"Get{GetControllerName()}", new { id = value.Id }, value);
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(GetErrorMessage(ex));
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Put(int id, [FromBody] TViewModel viewModel)
        {
            SetServiceUser();

            if (viewModel.Id != id) return BadRequest();
            await _service.ModifyAsync(viewModel);
            return Ok(viewModel);
        }

        [HttpPatch("{Id}")]
        public virtual async Task<IActionResult> Patch(int Id, [FromBody] JsonPatchDocument<TViewModel> pathDocument)
        {
            try
            {
                if (pathDocument is null) return BadRequest();
                TViewModel viewModel = await _service.GetAsync(Id);

                if (viewModel is null) return NotFound();
                pathDocument.ApplyTo(viewModel, ModelState);

                if (!TryValidateModel(viewModel)) return BadRequest(ModelState);

                SetServiceUser();
                await _service.ModifyAsync(viewModel);

                return Ok(viewModel);
            }
            catch (Exception ex) { return BadRequest(GetErrorMessage(ex)); }
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TViewModel>> Delete(int id)
        {
            SetServiceUser();

            var viewModel = await _service.GetAsync(id);
            if (viewModel is null) return NotFound();

            _service.Remove(viewModel);
            return Ok(viewModel);
        }

        private string GetControllerName() => 
            ControllerContext.RouteData.Values["controller"].ToString();

        private void SetServiceUser() 
            => _service.SetUser(GetUser());
       

        protected string GetUser() {
            if (User is null || !User.Claims.Any()) return string.Empty;
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

        public string GetErrorMessage(Exception error)
        {
            string errorMessage = string.Empty;
            errorMessage = error.Message;

            if (error.InnerException != null)
                errorMessage += " : " + GetErrorMessage(error.InnerException);

            return errorMessage;
        }
    } 
}
