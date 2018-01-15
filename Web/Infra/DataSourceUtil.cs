using Entity;
using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infra
{
    public static class DataSourceUtil
    {
        public static IQueryable<TModel> ToMyDataSourceResult<TModel>(this IQueryable<TModel> dataSourceResult, QueryInfo request) where TModel : BaseEntityClass
        {
            dataSourceResult.Skip(request.Skip).Take(request.Take);
            return dataSourceResult;
        }
    }
}