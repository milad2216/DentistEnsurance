using Entity.Services;
using Repository.Services;
using Service.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.impl
{
    public class UserPaymentService : BaseIntService<UserPayment, IUserPaymentRepository>, IUserPaymentService
    {
        protected UserPaymentService(IUserPaymentRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
