using Entity.File;
using Repository.File;
using Service.Base.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.File.Impl
{
    public class PersonalFileService : BaseIntService<PersonalFile, IPersonalFileRepository>, IPersonalFileService
    {
        public PersonalFileService(IPersonalFileRepository repository) : base(repository)
        {
            Repository = repository;
        }
    }
}
