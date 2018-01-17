using Entity.AccessControl;
using Repository.AccessControl;
using Service.Base.impl;

namespace Service.AccessControl.impl
{
    public class PersonalService : BaseIntService<Personal, IPersonalRepository>, IPersonalService
    {
        public PersonalService(IPersonalRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
