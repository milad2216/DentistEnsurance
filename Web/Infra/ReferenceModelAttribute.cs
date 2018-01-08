using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infra
{
    public class ReferenceModelAttribute : Attribute
    {
        public Type ReferenceModel { get; set; }

        public ReferenceModelAttribute(Type referenceModel)
        {
            ReferenceModel = referenceModel;
        }
    }
}