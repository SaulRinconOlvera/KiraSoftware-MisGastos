﻿using MisGastos.Domain.Model.Authorization;
using MisGastos.Domain.Services.Authorization.Interfaces;
using MisGastos.Web.Services.Controllers.Base;

namespace MisGastos.Web.Services.Areas.Authorization.Controllers
{
    public class RoleController : BaseAuthenticatedController<RoleViewModel>,
        IBaseController<RoleViewModel>
    {
        public RoleController(IRoleDomainService service)
            : base(service) { }
    }
}