using Entity.Duties;
using Repository.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Duties.impl
{
    public class UserPaymentRepository : BaseIntRepository<UserPayment>, IUserPaymentRepository
    {
        public override void InitiateDependencies()
        {
            InitiateDependencies(Context.UserPayments);
        }
    }
}
