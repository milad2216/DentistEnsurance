using Entity.AccessControl;
using Service.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.Controllers.Base;
using Web.Infra;
using Web.ViewModel.AccessControl;

namespace Web.Controllers
{
    public class SecurityController : BaseIntController<User, UserViewModel,IUserService>
    {
        public SecurityController(IUserService service)
        {
            Service = service;
        }
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            var entity = Service.FindBy(p => p.Username == username && p.Password == password).FirstOrDefault();
            if (entity != null)
            {
                HttpContext.Current.Session["LoginUser"] = entity.ToViewModel<UserViewModel>();
                HttpContext.Current.Session["IsAuthenticated"] = "true";
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = true });
            }
            else
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = false });
        }

        [HttpGet]
        public HttpResponseMessage LogOff()
        {
            HttpContext.Current.Session["IsAuthenticated"] = null;
            return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = false });
        }

        public HttpResponseMessage IsAuthenticated()
        {
            if((HttpContext.Current.Session["IsAuthenticated"]?.ToString()??"false") == "true")
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = true });
            else
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = false });
        }
    }
}
