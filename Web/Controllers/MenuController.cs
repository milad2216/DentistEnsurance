using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.ViewModel;
using Web.ViewModel.AccessControl;

namespace Web.Controllers
{
    public class MenuController : ApiController
    {

        public HttpResponseMessage GetMenu()
        {
            List<MenuViewModel> menus = new List<MenuViewModel>();
            List<MenuViewModel> shortcutMenus = new List<MenuViewModel>();
            if (((UserViewModel)HttpContext.Current.Session["LoginUser"]).UserType == 0)// admin
            {
                menus = new List<MenuViewModel> {
                    new MenuViewModel {Action="milad",Title="منو یک",Style="icon-dashboard" },
                    new MenuViewModel { Action = "home", Title = "منو دو", Style = "glyphicon-subscript" }
                };
                shortcutMenus = new List<MenuViewModel> {
                    new MenuViewModel { Action = "milad", Title = "منو یک", Style = "btn-info" },
                    new MenuViewModel { Action = "home", Title = "منو دو", Style = "btn-warning" }
               };
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { menus, shortcutMenus });
        }
    }
}
