using Entity.AccessControl;
using Repository.AccessControl;
using Service.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AccessControl.impl
{
    public class PersonalService : BaseIntService<Personal, IPersonalRepository>, IPersonalService
    {
        public PersonalService(IPersonalRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
