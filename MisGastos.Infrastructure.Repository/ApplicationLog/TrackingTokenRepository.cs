using MisGastos.Infrastructure.Entities.ApplicationLog;
using MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MisGastos.Infrastructure.Repository.ApplicationLog
{
    public class TrackingTokenRepository : 
        RepositoryBase<int, TrackingToken>, ITrackingTokenRepository
    {
        public TrackingTokenRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public async Task<TrackingToken> GetTokenAsync(Guid tokenId) 
        {
            var res = await GetAllMatchingAsync(t => t.TokenId == tokenId);
            return res.FirstOrDefault();
        }
    }
}