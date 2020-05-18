using Microsoft.Extensions.DependencyInjection;
using MisGastos.Domain.Services;
using MisGastos.Infrastructure.Repository;

namespace MisGastos.CrossCutting.DependencyInjection
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            RepositoryServices.Register(services);
            MapperServices.Register(services);
            DomainServiceServices.Register(services);
            IdentityConfiguration.Register(services);
        }
    }
}
