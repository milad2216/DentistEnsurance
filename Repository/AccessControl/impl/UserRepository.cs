using Entity.AccessControl;
using Repository.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AccessControl.impl
{
    public class UserRepository : BaseIntRepository<User>, IUserRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Users);
        }
    }
}
