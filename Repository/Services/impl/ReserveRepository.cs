using Entity.Services;
using Repository.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.impl
{
    public class ReserveRepository : BaseIntRepository<Reserve>
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Reserves);
        }
    }
}
