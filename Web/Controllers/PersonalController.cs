using Entity.AccessControl;
using Entity.Common;
using Service.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers.Base;
using Web.Infra;
using Web.ViewModel.AccessControl;

namespace Web.Controllers
{
    public class PersonalController : BaseIntController<Personal, PersonalViewModel, IPersonalService>
    {
        public PersonalController(IPersonalService service)
        {
            Service = service;
        }

        [HttpGet]
        public HttpResponseMessage Read(QueryInfo query)
        {
            var dataSourceResult = Service.GetAll().OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<Personal>();

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK, new { total = dataSourceResult.Count(), data = dataSourceResult });
        }
    }
}
