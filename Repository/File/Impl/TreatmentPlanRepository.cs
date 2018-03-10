using Entity.File;
using Repository.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.File.Impl
{
    public class TreatmentPlanRepository : BaseIntRepository<TreatmentPlan>, ITreatmentPlanRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.TreatmentPlans);
        }
    }
}
