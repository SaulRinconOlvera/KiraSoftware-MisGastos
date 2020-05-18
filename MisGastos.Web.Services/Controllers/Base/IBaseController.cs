using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MisGastos.Web.Services.Controllers.Base
{
    public interface IBaseController<IViewModel> 
        where IViewModel : IBaseViewModel<int>
    {
        Task<IEnumerable<IViewModel>> Get();
        Task<IViewModel> Get(int id);
        Task<ActionResult> Post([FromBody] IViewModel viewModel);
        Task<ActionResult> Put(int id, [FromBody] IViewModel viewModel);
        Task<ActionResult<IViewModel>> Delete(int id);
        //Task<ActionResult> UpLoadFile(IFormFile file);
        //Task<ActionResult> DownLoadFile(string fileName, string optionalFile = null);
        //ActionResult ProcessFile(string fileName);
        string GetErrorMessage(Exception error);
    }
}
