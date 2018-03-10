using AutoMapper;
using Entity.AccessControl;
using Entity.File;
using System;
using System.Collections.Generic;
using Web.Infra;
using Web.ViewModel.File;

namespace Web.ViewModel.AccessControl
{
    [ReferenceModelAttribute(typeof(Personal))]
    public class PersonalViewModel : BaseIntViewModel
    {
        public Int32 ParentId { get; set; }
        public String PersonalNo { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Relation { get; set; }
        public String NationalNo { get; set; }
        public String Unit { get; set; }
        public virtual ICollection<PersonalFileViewModel> Files { get; set; }

        public String FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<PersonalViewModel, Personal>();
            var modelToViewModel = Mapper.CreateMap<Personal, PersonalViewModel>();
        }
    }
}