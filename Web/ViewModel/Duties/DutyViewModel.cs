using AutoMapper;
using Entity.Duties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

namespace Web.ViewModel.Duties
{
    [ReferenceModelAttribute(typeof(Duty))]
    public class DutyViewModel : BaseIntViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public long Cost { get; set; }
        public Boolean IsActive { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<DutyViewModel, Duty>();
            var modelToViewModel = Mapper.CreateMap<Duty, DutyViewModel>();
        }
    }
}