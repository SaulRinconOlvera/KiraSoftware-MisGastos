using MisGastos.Infrastructure.DAL.Contexts;
using MisGastos.Infrastructure.Entities.Ubication;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Infrastructure.Repository.Ubication
{
    public class CityRepository : RepositoryBase<int, City>, ICityRepository
    {
        public CityRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
