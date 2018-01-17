using Entity.AccessControl;
using Repository.AccessControl;
using Service.Base.impl;

namespace Service.AccessControl.impl
{
    public class UserService : BaseIntService<User, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository): base(repository)
        {
            this.Repository = repository;
        }
    }
}
