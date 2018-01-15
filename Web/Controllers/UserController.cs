﻿using Entity.AccessControl;
using Entity.Common;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
    public class UserController : BaseIntController<User,UserViewModel,IUserService>
    {
        public UserController(IUserService service)
        {
            Service = service;
        }

        [HttpGet]
        public HttpResponseMessage Read(QueryInfo query)
        {
            var dataSourceResult = Service.GetAll().OrderByDescending(p => p.ID).ToMyDataSourceResult(query);

            //result = result.Skip(skip).Take(take);

            return Request.CreateResponse(HttpStatusCode.OK, new { total = dataSourceResult.Count(), data = dataSourceResult });
        }

    }
}
