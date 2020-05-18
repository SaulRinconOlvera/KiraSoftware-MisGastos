using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Domain.Services.Base;
using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Authorization.Interfaces;

namespace MisGastos.Domain.Services.Authorization
{
    public class RefreshTokenDomainService :
        DomainServiceBase<RefreshToken, RefreshTokenViewModel>, IRefreshTokenDomainService
    {
        public RefreshTokenDomainService(
            IRefreshTokenRepository repository,
            IMapper mapper) : base(mapper)
        { _repository = repository; }

        public async Task<RefreshTokenViewModel> GetTokenAsync(string tokenId)
        {
            var res = await _repository.GetAllMatchingAsync(tr => tr.Token == tokenId);
            var tokenRefresh = res.FirstOrDefault();

            if (tokenRefresh is null) return null;
            return _mapper.GetViewModel(tokenRefresh);
        }
    }
}