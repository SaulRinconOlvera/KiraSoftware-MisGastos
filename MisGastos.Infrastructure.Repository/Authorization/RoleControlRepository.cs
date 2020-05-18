using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;

namespace MisGastos.Infrastructure.Repository.Authorization
{
    public class RoleControlRepository : RepositoryBase<int, RoleControl>, IRoleControlRepository
    {
        public RoleControlRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}