using Entity.AccessControl;
using Service.AccessControl;
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
