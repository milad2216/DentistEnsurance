using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            return View();
        }
      
        public ActionResult Login()
        {
            return View();
        }
    }
}