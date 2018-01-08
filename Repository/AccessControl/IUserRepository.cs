using Entity.AccessControl;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AccessControl
{
    public interface IUserRepository : IBaseIntRepository<User>
    {
    }
}
