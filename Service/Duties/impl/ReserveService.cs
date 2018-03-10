using Entity.Duties;
using Repository.Duties;
using Service.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Duties.impl
{
    public class ReserveService : BaseIntService<Reserve, IReserveRepository>, IReserveService
    {
        public ReserveService(IReserveRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
