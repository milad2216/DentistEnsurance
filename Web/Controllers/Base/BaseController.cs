using Service.Base;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Web.Infra;
using Web.ViewModel;

namespace Web.Controllers.Base
{
    //[LastModifyFilter]
    //[LogFilter]
    //[CFErrorHandlerAttribute]
    //[MyAuthorizeAttribute]
    public abstract class BaseController<TModel, TViewModel, TService> : ApiController
        where TModel : class
        where TViewModel : class, IBaseViewModel
        where TService : IBaseService<TModel>
    {

        public TService Service { get; set; }
        public Type ViewModelType = typeof(TViewModel);
        public Type ModelType = typeof(TModel);
        protected int DropDownCount = 10;

        protected override void Dispose(bool disposing)
        {
            Service.Dispose();
            base.Dispose(disposing);
        }


        public HttpResponseMessage Create(TModel model)
        {
            var result = Service.Create(model);
            return MyResult(new ResultStructure(result));
        }


        public HttpResponseMessage Edit(TModel model)
        {
            var result = Service.Edit(model);
            return MyResult(new ResultStructure(result));
        }

        protected HttpResponseMessage MyResult(ResultStructure data)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, data);
        }
    }
}
