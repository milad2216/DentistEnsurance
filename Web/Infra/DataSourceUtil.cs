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
        public static MyDataSourceResult ToMyDataSourceResult<TModel>(this IQueryable<TModel> dataSourceResult, QueryInfo request) where TModel : BaseEntityClass
        {
            MyDataSourceResult res = new MyDataSourceResult();
            res.total = dataSourceResult.Count();
            if (request.Skip > 0) dataSourceResult = dataSourceResult.Skip(request.Skip);
            if (request.Take > 0) dataSourceResult = dataSourceResult.Take(request.Take);
            res.data = dataSourceResult.ToList();
            return res;
        }
    }
}