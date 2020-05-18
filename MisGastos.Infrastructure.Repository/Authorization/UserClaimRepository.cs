using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;

namespace MisGastos.Infrastructure.Repository.Authorization
{
    public class UserClaimRepository : RepositoryBase<int, UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
