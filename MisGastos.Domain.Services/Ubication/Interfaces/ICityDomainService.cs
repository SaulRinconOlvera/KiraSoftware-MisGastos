using MisGastos.Domain.Model.Ubication;
using MisGastos.Domain.Services.Base;

namespace MisGastos.Domain.Services.Ubication.Interfaces
{
    public interface ICityDomainService :
        IDomainServiceBase<int, CityViewModel>
    { }
}
