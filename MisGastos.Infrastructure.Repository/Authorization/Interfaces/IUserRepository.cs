using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Repository.Base.Interfaces;
using System.Threading.Tasks;

namespace MisGastos.Infrastructure.Repository.Authorization.Interfaces
{
    public interface IUserRepository : 
        IRepositoryBase<int, User> 
    {
        Task<User> LoginAsync(User entity);
        Task<User> SocialNetwiorkLoginAsync(string userId, string platform);
        Task LogoutAsync();
    }
}
