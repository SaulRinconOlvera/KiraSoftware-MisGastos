using AutoMapper;
using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Base;
using MisGastos.Domain.Services.Ubication.Interfaces;
using MisGastos.Infrastructure.Entities.Ubication;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Domain.Services.Ubication
{
    public class StateDomainService :
        DomainServiceBase<State, StateViewModel>, IStateDomainService
    {
        public StateDomainService(
            IStateRepository repository,
            IMapper mapper) : base(mapper)
        { _repository = repository; }
    }
}