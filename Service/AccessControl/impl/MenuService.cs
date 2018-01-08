using Entity.AccessControl;
using Repository.AccessControl;
using Service.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
