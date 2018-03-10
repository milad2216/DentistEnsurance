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
    public class TreatmentPlanController : BaseIntController<TreatmentPlan, TreatmentPlanViewModel, ITreatmentPlanService>
    {
        public TreatmentPlanController(ITreatmentPlanService service)
        {
            Service = service;
        }

        public HttpResponseMessage GetByFileId([FromUri]QueryInfo query, int fileId)
        {
            MyDataSourceResult dataSourceResult = new MyDataSourceResult();
            if(fileId > 0)
                dataSourceResult = Service.GetAll().Where(p => p.FileId == fileId).OrderByDescending(p => p.ID).ToMyDataSourceResult(query).ToViewModel<TreatmentPlanViewModel>(query);
            

            return MyResult(new ResultStructure { status = ResultCode.Success, data = dataSourceResult });
        }
    }
}
