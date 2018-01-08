using Entity;

namespace Repository.Base
{
    public interface IBaseIntRepository<TModel> : IBaseRepository<TModel> where TModel : BaseEntityClass 
    {
        TModel Find(int id);
      
        void Delete(int id);

    }
}