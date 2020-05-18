using MisGastos.CrossCutting.Utilities.Security;
using MisGastos.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Authorization
{
    public class RefreshTokenViewModel : BaseViewModel
    {

        public RefreshTokenViewModel() : base() { }
        public RefreshTokenViewModel(int userId) {
            UserId = userId;
            Token = TokenFactory.GenerateToken(64);
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }
        public UserViewModel User { get; set; }
    }
}
