using System;
using System.Threading.Tasks;
using AutoMapper;
using MisGastos.Domain.Model.ApplicationLog;
using MisGastos.Domain.Services.ApplicationLog.Interfaces;
using MisGastos.Domain.Services.Base;
using MisGastos.Infrastructure.Entities.ApplicationLog;
using MisGastos.Infrastructure.Repository.ApplicationLog.Interfaces;

namespace MisGastos.Domain.Services.ApplicationLog
{
    public class TrackingTokenDomainService :
        DomainServiceBase<TrackingToken, TrackingTokenViewModel>, ITrackingTokenDomainService
    {
        public TrackingTokenDomainService(
            ITrackingTokenRepository repository,
            IMapper mapper) : base(mapper)
        { _repository = repository; }

        public async Task DisableOldTokens(string UserName) =>
            await _repository.ExecSqlCommandAsync($"Exec DisableOldTokens '{UserName}'");

        public async Task<TrackingTokenViewModel> GetTokenAsync(Guid tokenId) 
        {
            var token = await (_repository as ITrackingTokenRepository).GetTokenAsync(tokenId);
            if (token is null) return null;

            return _mapper.GetViewModel(token);
        }
    }
}