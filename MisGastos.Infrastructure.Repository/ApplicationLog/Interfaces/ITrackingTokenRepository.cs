using MisGastos.Infrastructure.Entities.ApplicationLog;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using System;
using System.Threading.Tasks;

namespace MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces
{
    public interface ITrackingTokenRepository :
       IRepositoryBase<int, TrackingToken>
    {
        Task<TrackingToken> GetTokenAsync(Guid tokenId);
    }
}