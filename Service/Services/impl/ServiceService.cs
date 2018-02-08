using Service.Base.impl;
using Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Services;

namespace Service.Services.impl
{
    public class ServiceService : BaseIntService<Entity.Services.Service, IServiceRepository>, IServiceService
    {
        public ServiceService(IServiceRepository repository): base(repository)
        {
            this.Repository = repository;
        }
    }
}
