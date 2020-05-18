using MisGastos.Domain.Model.Base;
using MisGastos.Domain.Model.Navegation;
using System.ComponentModel.DataAnnotations;

namespace MisGastos.Domain.Model.Authorization
{
    public class RoleControlViewModel : BaseViewModel
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int ControlId { get; set; }

        public bool ApplyActionValidations { get; set; }
        public bool ApplySpecialActionValidations { get; set; }
        public int LevelAccess { get; set; }

        [StringLength(512)]
        public string SpecialActionsValues { get; set; }

        public virtual RoleViewModel Role { get; set; }
        public virtual ControlViewModel Control { get; set; }
    }
}
