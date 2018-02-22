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
using System.Data.Entity;
using Service.Duties;

namespace Web.Controllers
{
    public class SecurityController : BaseIntController<User, UserViewModel, IUserService>
    {
        IReserveService _reserveService;
        public SecurityController(IUserService service, IReserveService reserveService)
        {
            Service = service;
            _reserveService = reserveService;
        }
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            var entity = Service.GetAll().Include(x => x.Personal).Include(x => x.Reserves).Include(x => x.UserPayments).FirstOrDefault(p => p.Username == username && p.Password == password);
            if (entity != null)
            {
                var curUser = entity.ToViewModel<UserViewModel>();
                HttpContext.Current.Session["LoginUser"] = curUser;
                HttpContext.Current.Session["IsAuthenticated"] = "true";
                var userDoneReserves = _reserveService.GetAll().Include(x=>x.Duty).Where(p => p.UserId == entity.ID && p.Status != Entity.Common.ReserveStatusEnum.Denied && p.Status != Entity.Common.ReserveStatusEnum.Canceled).Sum(s => s.Duty.Cost);
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
