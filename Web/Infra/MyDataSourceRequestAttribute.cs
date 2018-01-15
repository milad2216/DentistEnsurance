using System;
using System.Web.Mvc;

namespace Web.Infra
{
    public class MyDataSourceRequestAttribute : CustomModelBinderAttribute
    {
        public string Prefix { get; set; }
        public Type ViewModelType { get; set; }

        public override IModelBinder GetBinder()
        {
            return new MyDataSourceRequestModelBinder() { Prefix = Prefix, ViewModelType = ViewModelType };
        }
    }
}