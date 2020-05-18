using MisGastos.Infrastructure.Entities.Ubication;
using MisGastos.Infrastructure.Repository.Base;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using MisGastos.Infrastructure.Repository.Ubication.Interfaces;

namespace MisGastos.Infrastructure.Repository.Ubication
{
    public class StateRepository : RepositoryBase<int, State>, IStateRepository
    {
        public StateRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
