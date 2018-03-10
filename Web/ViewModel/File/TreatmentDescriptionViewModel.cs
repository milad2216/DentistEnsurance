using AutoMapper;
using Entity.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

namespace Web.ViewModel.File
{
    [ReferenceModelAttribute(typeof(TreatmentDescription))]
    public class TreatmentDescriptionViewModel : BaseIntViewModel
    {
        public int FileId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public long Cost { get; set; }

        public long? Received { get; set; }

        public long Remainder { get; set; }
        public bool Reported { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<TreatmentDescriptionViewModel, TreatmentDescription>();
            var modelToViewModel = Mapper.CreateMap<TreatmentDescription, TreatmentDescriptionViewModel>();
        }
    }
}