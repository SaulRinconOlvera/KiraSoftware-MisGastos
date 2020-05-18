using Microsoft.Extensions.DependencyInjection;
using MisGastos.Domain.Services.ApplicationLog;
using MisGastos.Domain.Services.ApplicationLog.Interfaces;
using MisGastos.Domain.Services.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Domain.Services.Ubication;
using MisGastos.Domain.Services.Ubication.Interfaces;

namespace MisGastos.Domain.Services
{
    public static class DomainServiceServices
    {
        public static void Register(IServiceCollection services)
        {
            //  Ubication
            services.AddTransient<ICountryDomainService, CountryDomainService>();
            services.AddTransient<IStateDomainService, StateDomainService>();
            services.AddTransient<ICityDomainService, CityDomainService>();

            //  Authorization
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<IUserClaimDomainService, UserClaimDomainService>();
            services.AddTransient<IRoleDomainService, RoleDomainService>();
            services.AddTransient<IUserRoleDomainService, UserRoleDomainService>();
            services.AddTransient<IRoleControlDomainService, RoleControlDomainService>();
            services.AddTransient<IRefreshTokenDomainService, RefreshTokenDomainService>();

            //  Tracking
            services.AddTransient<ITrackingTokenDomainService, TrackingTokenDomainService>();
        }
    }
}
