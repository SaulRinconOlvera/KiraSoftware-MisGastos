using AutoMapper;
using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Base;
using MisGastos.Domain.Services.Ubication.Interfaces;
using MisGastos.Infrastructure.Entities.Ubication;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Domain.Services.Ubication
{
    public class CityDomainService :
        DomainServiceBase<City, CityViewModel>, ICityDomainService
    {
        public CityDomainService(
            ICityRepository repository,
            IMapper mapper) : base(mapper)
        {  _repository = repository; }
    }
}