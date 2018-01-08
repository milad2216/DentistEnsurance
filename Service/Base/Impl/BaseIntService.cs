using Repository.Base;
using Service.I18n;
using Service._I18n;
using Entity;

namespace Service.Base.impl
{
    public abstract class BaseIntService<TModel, TRepositoryType> : BaseService<TModel, TRepositoryType>, IBaseIntService<TModel> where TRepositoryType : IBaseIntRepository<TModel> 
        where TModel : BaseEntityClass
    {
        protected BaseIntService(TRepositoryType repository) : base(repository)
        {
        }

        public virtual CFResult Delete(int id)
        {
            Repository.Delete(id);
            if (Repository.Save() == 0)
            {
                return new CFResult { Status = "error", Message = LangUtil.Get("general_delete_failure") };
            }
            return new CFResult { Status = "success", Message = LangUtil.Get("general_delete_success") };
        }

        public virtual TModel FindById(int id)
        {
            return Repository.Find(id);
        }

    }
}
