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
    public class ReserveController : BaseIntController<Reserve, ReserveViewModel, IReserveService>
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

            return MyResult(new ResultStructure { status = ResultCode.Success, data = dataSourceResult });
        }

        [HttpPost]
        public HttpResponseMessage Cancel(Reserve model)
        {
            if (!model.Reported)
            {
                var res = Service.UpdateExp(p => p.ID == model.ID, u => new Reserve { Status = ReserveStatusEnum.Canceled });
                if (res > 0)
                {
                    return MyResult(new ResultStructure { status = ResultCode.Success, message = "با موفقیت لغو شد." });
                }
                else
                {
                    return MyResult(new ResultStructure { status = ResultCode.Error, message = "لغو با مشکل روبرو شد." });
                }
            }
            else
            {
                return MyResult(new ResultStructure { status = ResultCode.Error, message = "مورد انتخاب شده به مالی معرفی شده و قابل لغو نمیباشد." });
            }
        }

        public HttpResponseMessage GetStatusesAsList()
        {
            var list = Enum.GetValues(typeof(ReserveStatusEnum)).Cast<ReserveStatusEnum>().ToList();
            return MyResult(new ResultStructure { status = ResultCode.Success, data = list });
        }
    }
}
