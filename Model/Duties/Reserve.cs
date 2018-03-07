using Entity.AccessControl;
using Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Duties
{
    public class Reserve : BaseEntityClass
    {
        public int PersonalId { get; set; }
        public int DutyId { get; set; }
        public int UserId { get; set; }
        [EnumDataType(typeof(ReserveStatusEnum), ErrorMessage = "مقدار وضعیت رزرو اشتباه است")]
        public ReserveStatusEnum Status { get; set; }
        public string RequestMessage { get; set; }
        public bool Reported { get; set; } = false;
        public virtual Personal Personal { get; set; }
        public virtual Duty Duty { get; set; }
        public virtual User User { get; set; }
    }
}
