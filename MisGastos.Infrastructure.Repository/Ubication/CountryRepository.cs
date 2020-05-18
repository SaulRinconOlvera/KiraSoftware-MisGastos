using MisGastos.Infrastructure.Entities.Ubication;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Infrastructure.Repository.Ubication
{
    public class CountryRepository : RepositoryBase<int, Country>, ICountryRepository
    {
        public CountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
 