using System.Web.Mvc;
using Service.Base;
using Entity;
using Web.ViewModel;
using System.Net.Http;
using Web.Infra;

namespace Web.Controllers.Base
{
    public abstract class BaseIntController<TModel, TViewModel, TService> : BaseController<TModel, TViewModel, TService>
        where TModel : BaseEntityClass
        where TViewModel : BaseIntViewModel
        where TService : IBaseService<TModel>
    {

        [HttpPost]
        public virtual HttpResponseMessage Delete(int id)
        {
            var result = ((IBaseIntService<TModel>)Service).Delete(id);
            return MyResult(new ResultStructure(result));
        }
        
    }
}
