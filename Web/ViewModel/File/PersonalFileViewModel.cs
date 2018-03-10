using AutoMapper;
using Entity.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

namespace Web.ViewModel.File
{
    [ReferenceModelAttribute(typeof(PersonalFile))]
    public class PersonalFileViewModel : BaseIntViewModel
    {
        public int PersonalId { get; set; }

        public string FileNo { get; set; }

        public string SpecialDisease { get; set; }

        public string InsuranceType { get; set; }

        public string MedicalAlert { get; set; }

        public string Description { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<PersonalFileViewModel, PersonalFile>();
            var modelToViewModel = Mapper.CreateMap<PersonalFile, PersonalFileViewModel>();
        }
    }
}