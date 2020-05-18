using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Base.Interfaces;

namespace MisGastos.Infrastructure.Repository.Authorization.Interfaces
{
    public interface IRoleControlRepository :
        IRepositoryBase<int, RoleControl>
    { }
}
