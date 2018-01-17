using Entity.AccessControl;
using Repository.Base.impl;

namespace Repository.AccessControl.impl
{
    public class MenuRepository : BaseIntRepository<Menu>, IMenuRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Menus);
        }
    }
}
