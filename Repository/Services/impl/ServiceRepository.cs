using Entity.Services;
using Repository.Base.impl;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impl.Services
{
    class ServiceRepository : BaseIntRepository<Service>, IServiceRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.Services);
        }
    }
}
