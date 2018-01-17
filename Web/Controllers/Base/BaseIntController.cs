using System.Web.Mvc;
using Service.Base;
using Entity;
using Web.ViewModel;

namespace Web.Controllers.Base
{
    public abstract class BaseIntController<TModel, TViewModel, TService> : BaseController<TModel, TViewModel, TService>
        where TModel : BaseEntityClass
        where TViewModel : BaseIntViewModel
        where TService : IBaseService<TModel>
    {

        [HttpPost]
        public virtual JsonResult Delete(int id)
        {
            var result = ((IBaseIntService<TModel>)Service).Delete(id);
            return MyJsonResult(result);
        }
        
    }
}
