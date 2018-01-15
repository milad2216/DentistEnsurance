using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;

namespace Web.Infra
{
    public class MyDataSourceRequestModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var customFields = new List<CustomField>();
            Type viewModelType = null;
            var type =  controllerContext.Controller.GetType();
            var viewModelTypeInfo = type.GetField("ViewModelType");
            
            if (viewModelTypeInfo != null)
                viewModelType = (Type)viewModelTypeInfo.GetValue(controllerContext.Controller);

            if (ViewModelType != null)
                viewModelType = ViewModelType;

            if (viewModelType != null)
            {
                var propertyInfos = viewModelType.GetProperties();
                foreach (var propertyInfo in propertyInfos)
                {
                    var customFieldAttribute = propertyInfo.GetCustomAttributes<CustomFieldAttribute>(false).FirstOrDefault();
                    if (customFieldAttribute != null)
                        customFields.Add(new CustomField { Field = propertyInfo.Name, OrginalField = customFieldAttribute.Field });
                }
            }

            DataSourceRequest request = new DataSourceRequest();

            string sort, group, filter, aggregates;
            int currentPage, pageSize;


            if (TryGetValue(bindingContext, GridUrlParameters.Sort, out sort))
            {
                foreach (var customField in customFields)
                    sort = sort.Replace(customField.Field, customField.OrginalField);
                
                request.Sorts = GridDescriptorSerializer.Deserialize<SortDescriptor>(sort);
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Page, out currentPage))
                request.Page = currentPage;

            if (TryGetValue(bindingContext, GridUrlParameters.PageSize, out pageSize))
                request.PageSize = pageSize;

            if (TryGetValue(bindingContext, GridUrlParameters.Filter, out filter))
            {
                foreach (var customField in customFields)
                    filter = filter.Replace(customField.Field, customField.OrginalField);

                request.Filters = FilterDescriptorFactory.Create(filter);
            }

            if (TryGetValue(bindingContext, GridUrlParameters.Group, out group))
                request.Groups = GridDescriptorSerializer.Deserialize<GroupDescriptor>(group);

            if (TryGetValue(bindingContext, GridUrlParameters.Aggregates, out aggregates))
                request.Aggregates = GridDescriptorSerializer.Deserialize<AggregateDescriptor>(aggregates);

            return request;
        }

        public string Prefix { get; set; }
        public Type ViewModelType  { get; set; }

        private bool TryGetValue<T>(ModelBindingContext bindingContext, string key, out T result)
        {
            if (Prefix.HasValue())
                key = Prefix + "-" + key;

            var value = bindingContext.ValueProvider.GetValue(key);

            if (value == null)
            {
                result = default(T);

                return false;
            }

            result = (T)value.ConvertTo(typeof(T));

            if (typeof(T) == typeof(string))
                result = (T)Convert.ChangeType(result, typeof(T)); ;
            //result = (T)Convert.ChangeType(InfraUtils.ArabicCharsToPersian(result), typeof(T)); ;

            return true;
        }
    }

}