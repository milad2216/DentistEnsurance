using Entity.AccessControl;
using Repository.AccessControl;
using Service.Base.impl;

namespace Service.AccessControl.impl
{
    public class MenuService : BaseIntService<Menu, IMenuRepository>, IMenuService
    {
        public MenuService(IMenuRepository repository): base(repository)
        {
            this.Repository = repository;
        }
    }
}
