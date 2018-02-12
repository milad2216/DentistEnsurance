using Entity.Duties;
using Service.Duties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;
using Web.Infra;
using Web.ViewModel.Duties;

namespace Web.Controllers.Duties
{
    public class DutyController : BaseIntController<Duty, DutyViewModel, IDutyService>
    {
        public DutyController(IDutyService service)
        {
            Service = service;
        }

        public HttpResponseMessage GetAllService()
        {
            var services = Service.GetAll().Where(p => p.IsActive).ToViewModel<DutyViewModel>();
            return Request.CreateResponse(HttpStatusCode.OK, MyJsonResult(services));
        }
    }
}