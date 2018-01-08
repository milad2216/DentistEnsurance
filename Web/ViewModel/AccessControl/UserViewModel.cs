using AutoMapper;
using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;

namespace Web.ViewModel.AccessControl
{
    [ReferenceModelAttribute(typeof(User))]
    public class UserViewModel : BaseIntViewModel
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String NationalNo { get; set; }

        public String PersonalNo { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<UserViewModel, User>();
            var modelToViewModel = Mapper.CreateMap<User, UserViewModel>();
            //modelToViewModel.ForMember(cvm => cvm.PrcTypeCD, opt => opt.MapFrom(src => src.ProcessDet.PrcTypeCD));
        }
    }
}