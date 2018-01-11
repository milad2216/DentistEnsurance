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

        [HttpGet]
        public HttpResponseMessage Read()
        {
            IEnumerable<User> result = Service.GetAll().OrderByDescending(p => p.ID);

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK,new { total = result.Count(), data=result } );
        }

    }
}
