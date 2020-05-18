using MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;
using System;

namespace MisGastos.Infrastructure.Repository.Base.Interfaces
{
    public partial interface IUnitOfWork : IDisposable
    {
        //  Ubication
        ICountryRepository Countries { get; }
        IStateRepository States { get; }
        ICityRepository Cities { get; }

        //  Authorization
        IUserRepository Users { get; }
        IUserRoleRepository UsersRoles { get; }
        IUserLoginRepository UsersLogins { get; }
        IRoleRepository Roles { get; }
        IRoleControlRepository RoleControls { get; }
        IUserClaimRepository UserClaims { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        //  Tracking
        ITrackingTokenRepository TrakingTokens { get; }
    }
}
