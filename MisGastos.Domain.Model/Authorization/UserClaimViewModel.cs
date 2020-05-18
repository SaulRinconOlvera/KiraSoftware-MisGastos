using MisGastos.Domain.Model.Base;

namespace MisGastos.Domain.Model.Authorization
{
    public class UserClaimViewModel : BaseViewModel
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int UserId { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
