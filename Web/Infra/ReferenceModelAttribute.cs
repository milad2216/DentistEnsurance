using System;

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