using MisGastos.Domain.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Authorization
{
    public class RoleViewModel : BaseViewModel
    {
        [Required]
        [StringLength(128)]
        public virtual string Name { get; set; }
        public virtual string NormalizedName { get; set; }
        //public virtual string ConcurrencyStamp { get; set; }

        public virtual ICollection<UserRoleViewModel> Users { get; set; }
    }
}
