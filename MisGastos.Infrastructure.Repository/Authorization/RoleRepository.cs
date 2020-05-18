using Microsoft.AspNetCore.Identity;
using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Infrastructure.Repository.Authorization
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork) { }

        public async override Task AddAsync(Role entity, bool autoSave = true)
        {
            var result = await IdentityConfiguration.RoleManager.CreateAsync(entity);
            if (!result.Succeeded) ErrorOnCreate(result.Errors);
        }

        private void ErrorOnCreate(IEnumerable<IdentityError> errors)
        {
            string cadena = string.Empty;
            errors.ToList().ForEach(e => cadena += $"Error:'{e.Description}'\n");
            throw new Exception(cadena);
        }
    }  
}
