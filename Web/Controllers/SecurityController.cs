using Entity.AccessControl;
using Service.AccessControl;
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
    public class SecurityController : BaseIntController<User, UserViewModel, IUserService>
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
                var curUser = entity.ToViewModel<UserViewModel>();
                HttpContext.Current.Session["LoginUser"] = curUser;
                HttpContext.Current.Session["IsAuthenticated"] = "true";
                var userDoneReserves = entity.Reserves.Where(p => p.Status == Entity.Common.ReserveStatusEnum.Done).Sum(s => s.Service.Cost);
                var userPayments = entity.UserPayments.Sum(s => s.Amount);
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = true, User = curUser, UserCredit = ((entity.Salary + userPayments) - userDoneReserves) });
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
            if ((HttpContext.Current.Session["IsAuthenticated"]?.ToString() ?? "false") == "true")
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = true, UserType = ((UserViewModel)HttpContext.Current.Session["LoginUser"]).UserType });
            else
                return Request.CreateResponse(HttpStatusCode.OK, new { Authenticated = false });
        }
    }
}
