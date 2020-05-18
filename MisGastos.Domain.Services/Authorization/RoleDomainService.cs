using AutoMapper;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Domain.Services.Base;
using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;

namespace MisGastos.Domain.Services.Authorization
{
    public class RoleDomainService :
        DomainServiceBase<Role, RoleViewModel>, IRoleDomainService
    {
        public RoleDomainService(
            IRoleRepository repository,
            IMapper mapper) : base(mapper)
        { _repository = repository; }
    }
}