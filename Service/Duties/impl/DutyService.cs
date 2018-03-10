using Service.Base.impl;
using Entity.Duties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Duties;

namespace Service.Duties.impl
{
    public class DutyService : BaseIntService<Duty, IDutyRepository>, IDutyService
    {
        public DutyService(IDutyRepository repository): base(repository)
        {
            this.Repository = repository;
        }
    }
}
