using MisGastos.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Authorization
{
    public class UserRoleViewModel : BaseViewModel
    {
        [Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual int RoleId { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual RoleViewModel Role { get; set; }
    }
}
