using AutoMapper;
using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

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

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<PersonalViewModel, Personal>();
            var modelToViewModel = Mapper.CreateMap<Personal, PersonalViewModel>();
        }
    }
}