using Entity.Duties;
using Repository.Base.impl;
using Repository.Duties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impl.Duties
{
    public class DutyRepository : BaseIntRepository<Duty>, IDutyRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Duties);
        }
    }
}
