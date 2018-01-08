using Service.Base;
using System;
using System.Web.Http;
using System.Web.Mvc;
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
        public Type ViewModelType = typeof (TViewModel);
        public Type ModelType = typeof(TModel);
        protected int DropDownCount = 10;

        protected override void Dispose(bool disposing)
        {
            Service.Dispose();
            base.Dispose(disposing);
        }

     
        public virtual  JsonResult Create(TModel model)
        {
            var result = Service.Create(model);
            return MyJsonResult(result);
        }


        public virtual JsonResult Edit(TModel model)
        {
            var result = Service.Edit(model);
            return MyJsonResult(result);
        }

        protected JsonResult MyJsonResult(object data)
        {

            return new JsonResult
            {
                Data = data,
                ContentType = null,
                ContentEncoding = null,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
