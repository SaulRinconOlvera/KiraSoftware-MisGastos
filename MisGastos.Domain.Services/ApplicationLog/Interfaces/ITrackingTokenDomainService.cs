using MisGastos.Domain.Model.ApplicationLog;
using MisGastos.Domain.Services.Base;
using System;
using System.Threading.Tasks;

namespace MisGastos.Domain.Services.ApplicationLog.Interfaces
{
    public interface ITrackingTokenDomainService :
        IDomainServiceBase<int, TrackingTokenViewModel>
    {
        Task DisableOldTokens(string UserName);
        Task<TrackingTokenViewModel> GetTokenAsync(Guid tokenId);
    }
}