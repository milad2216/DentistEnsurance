using Entity.Common;
using Entity.Duties;
using Service.Duties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web.Controllers.Base;
using Web.Infra;
using Web.ViewModel.AccessControl;
using Web.ViewModel.Duties;

namespace Web.Controllers.Duties
{
    public class ReserveController : BaseIntController<Reserve,ReserveViewModel,IReserveService>
    {
        public ReserveController(IReserveService service)
        {
            Service = service;
        }


        public HttpResponseMessage GetReserves([FromUri]QueryInfo query, ReserveStatusEnum? status)
        {
            var curUser = (UserViewModel)HttpContext.Current.Session["LoginUser"];
            var dataSourceResult = Service.GetAll().Include(x => x.Personal).Include(x => x.Duty).Where(p => p.UserId == curUser.ID && (status == null || p.Status == status)).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<ReserveViewModel>(query);

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK, dataSourceResult);
        }

        [HttpPost]
        public HttpResponseMessage Cancel(Reserve model)
        {
            var res = Service.UpdateExp(p => p.ID == model.ID, u => new Reserve { Status = ReserveStatusEnum.Canceled });
            if (res > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status="success", message="با موفقیت لغو شد." });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { status = "error", message = "لغو با مشکل روبرو شد." });
            }
        }
    }
}
