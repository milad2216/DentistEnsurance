using AutoMapper;
using Entity.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

namespace Web.ViewModel.File
{
    [ReferenceModelAttribute(typeof(TreatmentPlan))]
    public class TreatmentPlanViewModel : BaseIntViewModel
    {
        public int FileId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public long Cost { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<TreatmentPlanViewModel, TreatmentPlan>();
            var modelToViewModel = Mapper.CreateMap<TreatmentPlan, TreatmentPlanViewModel>();
        }
    }
}