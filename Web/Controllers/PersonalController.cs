using Entity.AccessControl;
using Entity.Common;
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
    public class PersonalController : BaseIntController<Personal, PersonalViewModel, IPersonalService>
    {
        IUserService _userService;
        public PersonalController(IPersonalService service, IUserService userService)
        {
            Service = service;
            _userService = userService;
        }

        //[HttpGet]
       // [HttpPost]
        public HttpResponseMessage Get2([FromUri]QueryInfo query)
        {
            var dataSourceResult = Service.GetAll().Where(p=>p.ID == p.ParentId).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<PersonalViewModel>(query);

            //result = result.Skip(skip).Take(take);

            return MyResult(new ResultStructure { status = ResultCode.Success, data = dataSourceResult });
        }

        [HttpGet]
        public HttpResponseMessage ReadChildren([FromUri]QueryInfo query, int parentId)
        {
            var dataSourceResult = Service.GetAll().Where(p=>p.ParentId == parentId && p.ParentId != p.ID).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<PersonalViewModel>(query);

            //result = result.Skip(skip).Take(take);

            return MyResult(new ResultStructure { status = ResultCode.Success, data = dataSourceResult });
        }


        public HttpResponseMessage GetLoginUser()
        {
            var curUser = (UserViewModel)(HttpContext.Current.Session["LoginUser"]);
            return MyResult(new ResultStructure { status = ResultCode.Success, data = Service.FindById(curUser.PersonalId).ToViewModel<PersonalViewModel>() });
        }

        public HttpResponseMessage GetUserPersonals()
        {
            var curUser = (UserViewModel)(HttpContext.Current.Session["LoginUser"]);
            var persons = Service.FindBy(p => p.ParentId == curUser.PersonalId).ToViewModel<PersonalViewModel>();
            return MyResult(new ResultStructure { status = ResultCode.Success, data = persons });
        }
    }
}
