using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Data.Entity.Infrastructure;

namespace Service.Base
{
    public interface IBaseService<TModel> : IDisposable where TModel : class 
    {
        IDbSet<TModel> Entity { get; }

        TModel ConvertArabicToPersian(TModel model);

        CFResult Create(TModel model);
        CFResult CreateArabic(TModel model);
        Task<CFResult> CreateAsync(TModel model);

        CFResult Edit(TModel model, string[] blackFields = null, string[] whiteFields = null);
        Task<CFResult> EditAsync(TModel model, string[] blackFields = null, string[] whiteFields = null);

        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetAllIncluding(params Expression<Func<TModel, object>>[] includeProperties);

        int Count(Expression<Func<TModel, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TModel, bool>> predicate);

        IEnumerable GetGridData();

        List<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        Task<List<TModel>> FindByAsync(Expression<Func<TModel, bool>> predicate);

        IQueryable<TModel> Where(string predicate);

        int DeleteExp(Expression<Func<TModel, bool>> filterExpression);
        Task<int> DeleteExpAsync(Expression<Func<TModel, bool>> filterExpression);

        int UpdateExp(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression);
        Task<int> UpdateExpAsync(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression);

        
        HttpSessionState Session { get; }

        DbRawSqlQuery<TModel> GetBySqlQuery(string query, params object[] parameters);

        int GetCountBySqlQuery(string query, params object[] parameters);

        void ExecuteSqlQuery(string query, params object[] parameters);
    }
}
