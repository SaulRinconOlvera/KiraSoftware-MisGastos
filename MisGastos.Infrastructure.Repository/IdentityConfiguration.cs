using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MisGastos.Infrastructure.DAL.Contexts;
using MisGastos.Infrastructure.Entities.Identity;

namespace MisGastos.Infrastructure.Repository
{
    public static class IdentityConfiguration
    {
        public static void Register(IServiceCollection services) 
        {
            services.AddDbContext<Application_Context>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Application_Context>()
                .AddDefaultTokenProviders();

            UserManager = services.BuildServiceProvider().GetService<UserManager<User>>();
            SignManager = services.BuildServiceProvider().GetService<SignInManager<User>>();
            RoleManager = services.BuildServiceProvider().GetService<RoleManager<Role>>();
        }

        internal static UserManager<User> UserManager { get; private set; }
        internal static SignInManager<User> SignManager { get; private set; }
        internal static RoleManager<Role> RoleManager { get; private set; }
    }
}
