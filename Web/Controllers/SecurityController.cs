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
using Entity.Common;

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
                long? userDoneReserves = 0;
                if (curUser.UserType == UserType.Referred)
                {
                    var services = _reserveService.GetAll().Include(x => x.Duty).Where(p => p.UserId == entity.ID && p.Status != ReserveStatusEnum.Denied && p.Status != ReserveStatusEnum.Canceled);
                    if (services.Any())
                        userDoneReserves = services?.Sum(s => s.Duty != null ? s.Duty.Cost : 0) ?? (long)(0);
                    var userPayments = entity.UserPayments.Sum(s => s.Amount);

                    HttpContext.Current.Session["UserCredit"] = ((entity.Salary + userPayments) - (userDoneReserves ?? 0));
                }else
                {
                    HttpContext.Current.Session["UserCredit"] = 0;
                }
                return MyResult(new ResultStructure { status = ResultCode.Success, data = new { Authenticated = true, User = curUser, UserCredit = int.Parse(HttpContext.Current.Session["UserCredit"].ToString()) } });
            }
            else
                return MyResult(new ResultStructure { status = ResultCode.Error, data = new { Authenticated = false } });
        }

        [HttpGet]
        public HttpResponseMessage LogOff()
        {
            HttpContext.Current.Session["IsAuthenticated"] = null;
            return MyResult(new ResultStructure { status = ResultCode.Success, data = new { Authenticated = false } });
        }

        public HttpResponseMessage IsAuthenticated()
        {
            if ((HttpContext.Current.Session["IsAuthenticated"]?.ToString() ?? "false") == "true")
            {
                var curUser = (UserViewModel)HttpContext.Current.Session["LoginUser"];
                return MyResult(new ResultStructure { status = ResultCode.Success, data = new { Authenticated = true, User = curUser, UserCredit = int.Parse(HttpContext.Current.Session["UserCredit"].ToString()) } });
            }
            else
                return MyResult(new ResultStructure { status = ResultCode.Success, data = new { Authenticated = false } });
        }
    }
}
