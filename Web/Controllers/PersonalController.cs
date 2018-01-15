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
        public HttpResponseMessage Read([FromUri]QueryInfo query)
        {
            var dataSourceResult = Service.GetAll().Where(p=>p.ID == p.ParentId).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<PersonalViewModel>(query);

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK, dataSourceResult);
        }

        [HttpGet]
        public HttpResponseMessage ReadChildren([FromUri]QueryInfo query, int parentId)
        {
            var dataSourceResult = Service.GetAll().Where(p=>p.ParentId == parentId && p.ParentId != p.ID).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<PersonalViewModel>(query);

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK, dataSourceResult);
        }
    }
}
