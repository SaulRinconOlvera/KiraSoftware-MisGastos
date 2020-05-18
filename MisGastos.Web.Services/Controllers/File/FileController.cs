using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisGastos.CrossCutting.Utilities.Http;
using MisGastos.Web.Services.Utilities.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Web.Services.Controllers.File
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Route("Upload")]
        public virtual async Task<ActionResult> FileUpload([FromForm(Name = "file")] IFormFile file)
        {
            try
            {
                string name = $"{Guid.NewGuid().ToString()}.{file.FileName.Split('.').Last()}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), AppConfiguration.ImagesPath, name);
                using (var stream = new FileStream(@path, FileMode.Create))
                    await file.CopyToAsync(stream);

                return ProcessFile(name);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = GetErrorMessage(ex) });
            }
        }

        [HttpGet]
        [Route("Download")]
        public virtual async Task<ActionResult> DownLoadFile(string fileName, string optionalFile = null)
        {
            try
            {
                string file = Path.Combine(Directory.GetCurrentDirectory(), AppConfiguration.ImagesPath, fileName);
                if (!System.IO.File.Exists(file))
                {
                    if (string.IsNullOrWhiteSpace(optionalFile))
                        file = Path.Combine(Directory.GetCurrentDirectory(), AppConfiguration.ImagesPath, "default-user.jpg");
                    else file = Path.Combine(Directory.GetCurrentDirectory(), AppConfiguration.ImagesPath, optionalFile);
                }

                var memory = new MemoryStream();
                using (var stream = new FileStream(file, FileMode.Open))
                    await stream.CopyToAsync(memory);

                memory.Position = 0;
                return new FileStreamResult(memory, MimeTypeHandler.GetMimeType(file));
            }
            catch (Exception ex) { return BadRequest(new { error = GetErrorMessage(ex) }); }
        }

        public virtual ActionResult ProcessFile(string fileName)
        {
            return Ok(new { fileName });
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