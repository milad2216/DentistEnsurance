using Entity.Common;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infra
{
    public class ResultStructure
    {
        public ResultStructure()
        {

        }
        public ResultStructure(CFResult entity)
        {
            status = entity.Status == "success" ? ResultCode.Success : ResultCode.Error;
            data = entity.Extra?? new object();
            errors = entity.Errors;
            message = entity.Message;
        }
        public ResultCode status { get; set; }
        public object data { get; set; } = new object();
        public object errors { get; set; }
        public string message { get; set; }
    }
}