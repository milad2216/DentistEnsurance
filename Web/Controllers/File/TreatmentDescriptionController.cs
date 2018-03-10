using Entity.Common;
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
    public class TreatmentDescriptionController : BaseIntController<TreatmentDescription, TreatmentDescriptionViewModel, ITreatmentDescriptionService>
    {
        public TreatmentDescriptionController(ITreatmentDescriptionService service)
        {
            Service = service;
        }

        public HttpResponseMessage GetByFileId([FromUri]QueryInfo query, int fileId)
        {
            var dataSourceResult = Service.GetAll().Where(p => p.FileId == fileId).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<TreatmentDescriptionViewModel>(query);


            return MyResult(new ResultStructure { status = ResultCode.Success, data = dataSourceResult });
        }

        [HttpPut]
        public override HttpResponseMessage Edit(TreatmentDescription model)
        {
            ResultStructure result = new ResultStructure();
            if (!model.Reported)
            {
                result = new ResultStructure(Service.Edit(model));
            }
            else
            {
                result = new ResultStructure { status = ResultCode.AccessDenid, message = "رکورد انتخاب شده به دلیل گزارش به مالی قابل ویرایش نیست." };
            }
            return MyResult(result);

        }
    }
}
