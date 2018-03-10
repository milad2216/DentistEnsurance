using Entity.File;
using Service.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers.Base;
using Web.Infra;
using Web.ViewModel.File;

namespace Web.Controllers.File
{
    public class PersonalFileController : BaseIntController<PersonalFile,PersonalFileViewModel,IPersonalFileService>
    {
        public PersonalFileController(IPersonalFileService service)
        {
            Service = service;
        }

        [HttpPost]
        public HttpResponseMessage Save(PersonalFile model)
        {
            ResultStructure res;
            if (model.ID > 0)
            {
                res = new ResultStructure(Service.Edit(model));
            }
            else
            {
                res = new ResultStructure(Service.Create(model));
                res.data = new { ID = model.ID };
            }
            return MyResult(res);
        }
    }
}
