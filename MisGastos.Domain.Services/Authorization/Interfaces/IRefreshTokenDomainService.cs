using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Base;
using System;
using System.Threading.Tasks;

namespace MisGastos.Domain.Services.Authorization.Interfaces
{
    public interface IRefreshTokenDomainService :
        IDomainServiceBase<int, RefreshTokenViewModel>
    {
        Task<RefreshTokenViewModel> GetTokenAsync(string tokenId);
    }
}