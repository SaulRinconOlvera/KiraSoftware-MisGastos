using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MisGastos.Domain.Model.ApplicationLog;
using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Model.Navegation;
using MisGastos.Domain.Model.Ubication;
using MisGastos.Infrastructure.Entities.ApplicationLog;
using MisGastos.Infrastructure.Entities.Identity;
using MisGastos.Infrastructure.Entities.Navegation;
using MisGastos.Infrastructure.Entities.Ubication;

namespace MisGastos.Domain.Services
{
    public static class MapperServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(op => {
                op.CreateMap<Country, CountryViewModel>().ReverseMap();
                op.CreateMap<State, StateViewModel>().ReverseMap();
                op.CreateMap<City, CityViewModel>().ReverseMap();
                op.CreateMap<User, UserViewModel>()
                    .ForMember(m => m.PasswordHash, o => o.Ignore())
                    .ForMember(m => m.SecurityStamp, o => o.Ignore());
                op.CreateMap<UserLogin, UserLoginViewModel>().ReverseMap();
                op.CreateMap<UserClaim, UserClaimViewModel>().ReverseMap();
                op.CreateMap<UserViewModel, User>();
                op.CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
                op.CreateMap<Role, RoleViewModel>().ReverseMap();
                op.CreateMap<RoleControl, RoleControlViewModel>().ReverseMap();
                op.CreateMap<Control, ControlViewModel>().ReverseMap();
                op.CreateMap<RefreshToken, RefreshTokenViewModel>().ReverseMap();
                op.CreateMap<TrackingToken, TrackingTokenViewModel>().ReverseMap();
            }, typeof(MapperServices));
        }
    }
}
