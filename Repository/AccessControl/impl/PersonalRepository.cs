using Entity.AccessControl;
using Repository.Base.impl;

namespace Repository.AccessControl.impl
{
    public class PersonalRepository : BaseIntRepository<Personal>, IPersonalRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Personals);
        }
    }
}
