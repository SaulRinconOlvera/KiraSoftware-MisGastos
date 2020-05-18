using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.ApplicationLog.Interfaces;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Web.Services.Areas.Authorization.Model;
using MisGastos.Web.Services.Controllers.Base;
using MisGastos.Web.Services.Utilities.Configuration;
using MisGastos.Web.Services.Utilities.JWT;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Web.Services.Areas.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : BaseAuthenticatedController<UserViewModel>, IBaseController<UserViewModel>
    {
        private IRoleControlDomainService _roleControlService;
        private ITrackingTokenDomainService _trackingTokenDomainService;
        private IRefreshTokenDomainService _refreshTokenDomainService;

        public UserController(
            IUserDomainService service,
            ITrackingTokenDomainService trackingTokenDomainService,
            IRefreshTokenDomainService refreshTokenDomainService,
            IRoleControlDomainService roleControlService) : base(service)
        {
            _roleControlService = roleControlService;
            _refreshTokenDomainService = refreshTokenDomainService;
            _trackingTokenDomainService = trackingTokenDomainService;
        }

        [AllowAnonymous]
        public override Task<ActionResult> Post([FromBody] UserViewModel viewModel)
        {
            return base.Post(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(
            [FromBody] UserViewModel viewModel, string origin, string action)
        {
            try
            {
                if (origin is null) return await ProcessLocalUSer(viewModel);
                else return await ProcessSocialNetworkUser(viewModel, origin, action);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Logout")]
        public async Task<IActionResult> LogOut([FromBody] TokenInformationViewModel dataRefreshToken) 
        {
            var tokenError = new { Error = "Invalid token" };

            if (!ValidateDataRefreshToken(dataRefreshToken)) return BadRequest(tokenError);

            string tokenId = Token.GetTokenId(dataRefreshToken.CurrentJWToken);
            if (string.IsNullOrWhiteSpace(tokenId)) return BadRequest(tokenError);

            var trackingToken = await _trackingTokenDomainService.GetTokenAsync(new Guid(tokenId));
            if (trackingToken is null) return BadRequest(tokenError);

            if (!Token.ValidateToken(dataRefreshToken.CurrentJWToken, trackingToken, this.GetUser())) // "saulrincon@hotmail.com"
                return BadRequest(tokenError);

            var tokenRefresh = await _refreshTokenDomainService.GetTokenAsync(dataRefreshToken.RefreshToken);
            if (tokenRefresh is null) return BadRequest(tokenError);

            if (tokenRefresh.UserId != trackingToken.UserId || 
                tokenRefresh.UserId != dataRefreshToken.UserId)
                return BadRequest(tokenError);

            _trackingTokenDomainService.Remove(trackingToken);

            await (_service as IUserDomainService).Logout();
            return Ok();
        }

        [NonAction]
        private bool ValidateDataRefreshToken(TokenInformationViewModel dataRefreshToken) 
        {
            return dataRefreshToken != null &&
                !string.IsNullOrWhiteSpace(dataRefreshToken.CurrentJWToken) &&
                !string.IsNullOrWhiteSpace(dataRefreshToken.RefreshToken);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(
            [FromBody] TokenInformationViewModel dataRefreshToken)
        {
            var tokenError = new { Error = "Invalid token" };

            if (dataRefreshToken is null ||
                string.IsNullOrWhiteSpace(dataRefreshToken.CurrentJWToken) ||
                string.IsNullOrWhiteSpace(dataRefreshToken.RefreshToken))
                return BadRequest(tokenError);

            string tokenId = Token.GetTokenId(dataRefreshToken.CurrentJWToken);
            if (string.IsNullOrWhiteSpace(tokenId)) return BadRequest(tokenError);

            var trackingToken =
                await _trackingTokenDomainService.GetTokenAsync(new Guid(tokenId));

            if (trackingToken is null) return BadRequest(tokenError);

            if (!Token.ValidateToken(dataRefreshToken.CurrentJWToken, trackingToken, this.GetUser())) // "saulrincon@hotmail.com"
                return BadRequest(tokenError);

            var tokenRefresh = await _refreshTokenDomainService.GetTokenAsync(dataRefreshToken.RefreshToken);
            if (tokenRefresh is null) return BadRequest(tokenError);

            if (tokenRefresh.UserId != trackingToken.UserId)
                return BadRequest(tokenError);

            var userResult = await _service.GetAsync(tokenRefresh.UserId);
            if(userResult is null) return BadRequest(tokenError);

            return await ProcessResult(userResult);
        }

        [HttpPatch("{Id}")]
        [AllowAnonymous]
        public override async Task<IActionResult> Patch(int Id, [FromBody] JsonPatchDocument<UserViewModel> pathDocument)
        {
            try
            {
                if (pathDocument is null) return BadRequest();
                var userViewModel = await ((IUserDomainService)_service).GetForModifyAsync(Id);

                if (userViewModel is null) return NotFound();

                DeleteOldImageFile(pathDocument, userViewModel);

                pathDocument.ApplyTo(userViewModel, ModelState);

                if (!TryValidateModel(userViewModel)) return BadRequest(ModelState);
                await _service.ModifyAsync(userViewModel);

                userViewModel.PasswordHash = null;
                userViewModel.SecurityStamp = null;

                return Ok(userViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(GetErrorMessage(ex));
            }
        }
        private async Task<IActionResult> ProcessLocalUSer(UserViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await ((IUserDomainService)_service).LoginAsync(viewModel);
            return await ProcessResult(result);
        }

        private async Task<IActionResult> ProcessSocialNetworkUser(UserViewModel viewModel, string origin, string action)
        {
            if (viewModel.Logins is null || !viewModel.Logins.Any())
                return BadRequest("There are't information about social network user.");

            var result = await ((IUserDomainService)_service).SocialNetwiorkLoginAsync(
                    viewModel.Logins.FirstOrDefault().ProviderKey,
                    viewModel.Logins.FirstOrDefault().LoginProvider);

            if (result != null) return await ProcessResult(result);
            if (action == "only_login") return NotFound("User not registred.");
            return await base.Post(viewModel);
        }

        private async Task<IActionResult> ProcessResult(UserViewModel result)
        {
            if (result != null)
            {
                await GetRoleControlsAsync();
                var trackingToken = Token.Build(result);
                await _trackingTokenDomainService.DisableOldTokens(result.UserName);
                await _trackingTokenDomainService.AddAsync(trackingToken);

                result.Token = trackingToken.Token;
                return Ok(result);
            }
            else return BadRequest("The username or password are wrong");
        }

        private async Task GetRoleControlsAsync()
        {
            var result = await _roleControlService.GetAllAsync(new string[] { "Role", "Control" });
            AppConfiguration.RoleControls = result;
        }

        private void DeleteOldImageFile(JsonPatchDocument<UserViewModel> pathDocument, UserViewModel userViewModel)
        {
            var avatar = pathDocument.Operations.Where(o => o.path == "/avatar").FirstOrDefault();
            if (avatar is null || userViewModel.Avatar is null) return;

            string file = Path.Combine(Directory.GetCurrentDirectory(), AppConfiguration.ImagesPath, userViewModel.Avatar);
            if (System.IO.File.Exists(file))
            {
                try { System.IO.File.Delete(file); }
                catch { }
            }
        }
    }
}