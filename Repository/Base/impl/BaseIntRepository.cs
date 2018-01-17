using Entity;

namespace Repository.Base.impl
{
    public abstract class BaseIntRepository<TModel> : BaseRepository<TModel>, IBaseRepository<TModel> where TModel : BaseEntityClass
    {

        protected BaseIntRepository(string catalog, int? timeout = null) : base(catalog,timeout)
        {
            InitiateDependencies();
        } 
        protected BaseIntRepository()
        {
            InitiateDependencies();
        }

        public TModel Find(int id)
        {
            return Entity.Find(id);
        }
       
        public void Delete(int id)
        {
            var balancesheetmodel = Entity.Find(id);
            Entity.Remove(balancesheetmodel);
        }    
        
    }
}
