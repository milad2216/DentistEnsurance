using Entity.AccessControl;
using Service.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers.Base;
using Web.ViewModel.AccessControl;

namespace Web.Controllers
{
    public class UserController : BaseIntController<User,UserViewModel,IUserService>
    {
        public UserController(IUserService service)
        {
            Service = service;
        }
    }
}
