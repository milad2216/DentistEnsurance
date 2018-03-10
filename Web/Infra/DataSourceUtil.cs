using Entity;
using Entity.Common;
using System.Linq;

namespace Web.Infra
{
    public static class DataSourceUtil
    {
        public static MyDataSourceResult ToMyDataSourceResult<TModel>(this IQueryable<TModel> dataSourceResult, QueryInfo request) where TModel : BaseEntityClass
        {
            if (request.Filter != null && request.Filter.Filters != null && request.Filter.Filters.Count() > 0)
                dataSourceResult = dataSourceResult.Where(FilterInfoTranslator.CreateSearchExpression<TModel>(request.Filter));
            MyDataSourceResult res = new MyDataSourceResult();
            res.total = dataSourceResult.Count();
            if (request.Skip > 0) dataSourceResult = dataSourceResult.Skip(request.Skip);
            if (request.Take > 0) dataSourceResult = dataSourceResult.Take(request.Take);
            res.data = dataSourceResult.ToList();
            return res;
        }
    }
}