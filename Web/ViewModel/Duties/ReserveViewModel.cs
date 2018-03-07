using AutoMapper;
using Entity.Common;
using Entity.Duties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infra;
using Web.ViewModel.AccessControl;

namespace Web.ViewModel.Duties
{
    [ReferenceModelAttribute(typeof(Reserve))]
    public class ReserveViewModel : BaseIntViewModel
    {
        public Int32 PersonalId { get; set; }
        public Int32 ServiceId { get; set; }
        public Int32 UserId { get; set; }
        public ReserveStatusEnum Status { get; set; }
        public string RequestMessage { get; set; }
        public bool Reported { get; set; }
        public DateTime? TurnDateTime { get; set; }
        public PersonalViewModel Personal { get; set; }
        public DutyViewModel Duty { get; set; }
        public override void CreateMappings()
        {
            var viewModelToModel = Mapper.CreateMap<ReserveViewModel, Reserve>();
            var modelToViewModel = Mapper.CreateMap<Reserve, ReserveViewModel>();
            modelToViewModel.ForMember(cvm => cvm.Personal, opt => opt.MapFrom(src => src.Personal.ToViewModel<PersonalViewModel>()));
            modelToViewModel.ForMember(cvm => cvm.Duty, opt => opt.MapFrom(src => src.Duty.ToViewModel<DutyViewModel>()));
        }
    }
}