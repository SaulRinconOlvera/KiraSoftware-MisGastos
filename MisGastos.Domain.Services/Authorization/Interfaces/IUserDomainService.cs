using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Base;
using System.Threading.Tasks;

namespace MisGastos.Domain.Services.Authorization.Interfaces
{
    public interface IUserDomainService :
        IDomainServiceBase<int, UserViewModel>
    {
        Task<UserViewModel> LoginAsync(UserViewModel userViewModel);
        Task<UserViewModel> SocialNetwiorkLoginAsync(string userId, string platform);
        Task<UserViewModel> GetForModifyAsync(int viewModelId);
        UserViewModel GetForModify(int viewModelId);
        Task Logout();
    }
}
