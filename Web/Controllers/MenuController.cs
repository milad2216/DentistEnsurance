using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.ViewModel;

namespace Web.Controllers
{
    public class MenuController : ApiController
    {

        public HttpResponseMessage GetMenu()
        {
            var menus = new List<MenuViewModel> {
                new MenuViewModel {Action="milad",Title="منو یک",Style="icon-dashboard" },
                new MenuViewModel { Action = "home", Title = "منو دو", Style = "glyphicon-subscript" }
            };
            var shortcutMenus = new List<MenuViewModel> {
                new MenuViewModel { Action = "milad", Title = "منو یک", Style = "btn-info" },
                new MenuViewModel { Action = "home", Title = "منو دو", Style = "btn-warning" }
           };
            return Request.CreateResponse(HttpStatusCode.OK, new {  menus, shortcutMenus });
        }
    }
}
