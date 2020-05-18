using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Base;

namespace MisGastos.Domain.Services.Authorization.Interfaces
{
    public interface IRoleDomainService :
        IDomainServiceBase<int, RoleViewModel>
    { }
}
