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
    public class ReserveService : BaseIntService<Reserve, IReserveRepository>, IReserveService
    {
        protected ReserveService(IReserveRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
