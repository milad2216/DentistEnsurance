using AutoMapper;
using Entity.AccessControl;
using System;
using Web.Infra;

namespace Web.ViewModel.AccessControl
{
    [ReferenceModelAttribute(typeof(User))]
    public class UserViewModel : BaseIntViewModel
    {
        public Int32 PersonalId { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public Int32 Salary { get; set; }

        public Int32 UserType { get; set; }

        public Int32 ParentId { get; set; }

        public String PersonalNo { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Relation { get; set; }

        public String NationalNo { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public String Unit { get; set; }

        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<UserViewModel, User>();
            var modelToViewModel = Mapper.CreateMap<User, UserViewModel>();
            modelToViewModel.ForMember(cvm => cvm.ParentId, opt => opt.MapFrom(src => src.Personal.ParentId));
            modelToViewModel.ForMember(cvm => cvm.PersonalNo, opt => opt.MapFrom(src => src.Personal.PersonalNo));
            modelToViewModel.ForMember(cvm => cvm.FirstName, opt => opt.MapFrom(src => src.Personal.FirstName));
            modelToViewModel.ForMember(cvm => cvm.LastName, opt => opt.MapFrom(src => src.Personal.LastName));
            modelToViewModel.ForMember(cvm => cvm.Relation, opt => opt.MapFrom(src => src.Personal.Relation));
            modelToViewModel.ForMember(cvm => cvm.NationalNo, opt => opt.MapFrom(src => src.Personal.NationalNo));
            modelToViewModel.ForMember(cvm => cvm.Unit, opt => opt.MapFrom(src => src.Personal.Unit));
        }
    }
}