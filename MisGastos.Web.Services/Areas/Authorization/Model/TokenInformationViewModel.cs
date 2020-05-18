namespace MisGastos.Web.Services.Areas.Authorization.Model
{
    public class TokenInformationViewModel
    {
        public string CurrentJWToken { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}
