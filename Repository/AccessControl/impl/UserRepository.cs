using Entity.AccessControl;
using Repository.Base.impl;

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
