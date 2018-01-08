using Entity;

namespace Service.Base
{
    public interface IBaseIntService<TModel> : IBaseService<TModel> where TModel : BaseEntityClass
    {
        CFResult Delete(int id);

        TModel FindById(int id);


    }
}
