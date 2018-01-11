using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class SecurityController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
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
