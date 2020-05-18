using Microsoft.Extensions.DependencyInjection;
using MisGastos.Infrastructure.Repository.ApplicationLog;
using MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces;
using MisGastos.Infrastructure.Repository.Authorization;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Infrastructure.Repository
{
    public static class RepositoryServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserLoginRepository, UserLoginRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleControlRepository, RoleControlRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            //  Tracking
            services.AddTransient<ITrackingTokenRepository, TrackingTokenRepository>();
        }
    }
}
