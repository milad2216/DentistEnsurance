using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Configuration;

namespace Repository.Base
{
    public interface IBaseRepository<TModel> : IDisposable where TModel : class 
    {
        InsuranceEntities Context { get; set; }

        InsuranceEntities ContextByTimeout(int timeout);

        IDbSet<TModel> Entity { get; set; }

        IQueryable<TModel> All { get; }

        IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties);

        List<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        Task<List<TModel>> FindByAsync(Expression<Func<TModel, bool>> predicate);

        IQueryable<TModel> Where(string predicate);

        int Count(Expression<Func<TModel, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TModel, bool>> predicate);

        void Insert(TModel model);

        void Update(TModel model, string[] blackFields = null, string[] whiteFields = null);

        int DeleteExp(Expression<Func<TModel, bool>> filterExpression);
        Task<int> DeleteExpAsync(Expression<Func<TModel, bool>> filterExpression);

        int UpdateExp(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression);
        Task<int> UpdateExpAsync(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression);

        int Save();
        void SaveAsync();

        void InitiateDependencies(IDbSet<TModel> entity);

        void InitiateDependencies();

        DbRawSqlQuery<TModel> GetBySqlQuery(string query, params object[] parameters);

        int GetCountBySqlQuery(string query, params object[] parameters);

        void ExecuteSqlQuery(string query, params object[] parameters);
    }
}