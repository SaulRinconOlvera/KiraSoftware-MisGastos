using MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces;
using MisGastos.Infrastructure.Repository.Authorization;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Infrastructure.Repository.Base
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private void InitRepositories()
        {
            //  Ubication
            Countries = new CountryRepository(this);
            States = new StateRepository(this);
            Cities = new CityRepository(this);

            //  Authorization
            Users = new UserRepository(this);
            UsersRoles = new UserRoleRepository(this);
            UsersLogins = new UserLoginRepository(this);
            Roles = new RoleRepository(this);
            RoleControls = new RoleControlRepository(this);
            UserClaims = new UserClaimRepository(this);
            RefreshTokens = new RefreshTokenRepository(this);
        }

        //  Ubication
        public ICountryRepository Countries { get; private set; }
        public IStateRepository States { get; private set; }
        public ICityRepository Cities { get; private set; }

        //  Authorization
        public IUserRepository Users { get; private set; }
        public IUserRoleRepository UsersRoles { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IRoleControlRepository RoleControls { get; private set; }
        public IRefreshTokenRepository RefreshTokens { get; private set; }

        public IUserLoginRepository UsersLogins { get; private set; }
        public IUserClaimRepository UserClaims { get; private set; }


        //  Tracking
        public ITrackingTokenRepository TrakingTokens { get; private set; }
    }

}
