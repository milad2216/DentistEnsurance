using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.ComponentModel;
using Configuration;

namespace Repository.Base.impl
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        private InsuranceEntities _context;
        private string _catalog = null;
        private int? _timeout = null;
        public InsuranceEntities Context
        {
            get
            {
                return _context ?? (_context = new InsuranceEntities("name=InsuranceEntities"));
            }
            set { _context = value; }
        }

        public InsuranceEntities ContextByTimeout(int timeout)
        {
            return new InsuranceEntities(ConfigurationManager.ConnectionStrings["InsuranceEntities"].ConnectionString, timeout);
        }

        private IDbSet<TModel> _entity;

        public IDbSet<TModel> Entity
        {
            get
            {
                if (_entity == null)
                    InitiateDependencies();
                return _entity;
            }
            set { _entity = value; }

        }

        public void InitiateDependencies(IDbSet<TModel> entity)
        {
            Entity = entity;
        }

        abstract public void InitiateDependencies();

        protected BaseRepository(string catalog, int? timeout= null)
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            this._catalog = catalog;
            this._timeout = timeout;
            InitiateDependencies();
        }
        protected BaseRepository(int? timeout = null)
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            this._timeout = timeout;
            InitiateDependencies();
        }

        protected BaseRepository()
        {
            this._catalog = null;
            InitiateDependencies();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IQueryable<TModel> All
        {
            get { return Entity.AsQueryable(); }
        }


        public IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = Entity;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }


        public List<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            return Context.Set<TModel>().Where(predicate).ToList();
        }

        public Task<List<TModel>> FindByAsync(Expression<Func<TModel, bool>> predicate)
        {
            return Context.Set<TModel>().Where(predicate).ToListAsync();
        }

        public IQueryable<TModel> Where(string predicate)
        {
            return Entity.Where(predicate);
        }

        public int Count(Expression<Func<TModel, bool>> predicate)
        {
            return Context.Set<TModel>().Count(predicate);
        }
        public Task<int> CountAsync(Expression<Func<TModel, bool>> predicate)
        {
            return Context.Set<TModel>().CountAsync(predicate);
        }

        public void Insert(TModel model)
        {
            //model.CreatedAt = DateTime.Now;
            Entity.Add(model);
        }

        public void Update(TModel model, string[] blackFields = null, string[] whiteFields = null)
        {
            //model.UpdatedAt = DateTime.Now;
            Context.Entry(model).State = EntityState.Modified;

            var entry = Context.Entry(model);
            if (blackFields != null)
            {
                foreach (var name in blackFields)
                {
                    entry.Property(name).IsModified = false;
                }
            }

            if (whiteFields != null)
            {
                //var entry = Context.Entry(model);
                PropertyInfo[] propertyInfos = model.GetType().GetProperties();
                foreach (var propertyInfo in propertyInfos)
                {
                    try
                    {
                        if (!whiteFields.Contains(propertyInfo.Name))
                        {
                            if (propertyInfo.PropertyType.BaseType != null && propertyInfo.PropertyType.BaseType.Name !=
                                        "BaseGuidEntityClass" && propertyInfo.PropertyType.BaseType.Name != "BaseIntEntityClass" &&
                                        propertyInfo.PropertyType.BaseType.Name != "BaseEntityClass")
                                entry.Property(propertyInfo.Name).IsModified = false;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        //
                    }
                }
                foreach (var name in whiteFields)
                {
                    entry.Property(name).IsModified = true;
                }
            }
        }

        public int DeleteExp(Expression<Func<TModel, bool>> filterExpression)
        {
            return Entity.Where(filterExpression).Delete();
        }
        public Task<int> DeleteExpAsync(Expression<Func<TModel, bool>> filterExpression)
        {
            return Entity.Where(filterExpression).DeleteAsync();
        }

        public int UpdateExp(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression)
        {
            return Entity.Where(filterExpression).Update(updateExpression);
        }

        public Task<int> UpdateExpAsync(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression)
        {
            return Entity.Where(filterExpression).UpdateAsync(updateExpression);
        }

        public int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //var dbEntityValidationResults = ex.EntityValidationErrors;
                //ex.EntityValidationErrors.Count();
                return 0;
            }

            catch (DbUpdateException ex)
            {
                //var dbEntityValidationResults = ex.Entries;
                //ex.Entries.Count();
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public void SaveAsync()
        {
            try
            {
                Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var dbEntityValidationResults = ex.EntityValidationErrors;
                ex.EntityValidationErrors.Count();
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbRawSqlQuery<TModel> GetBySqlQuery(string query, params object[] parameters)
        {
            return Context.Database.SqlQuery<TModel>(query, parameters);
        }

        public int GetCountBySqlQuery(string query, params object[] parameters)
        {
            return Context.Database.SqlQuery<int>(query,parameters).First();
        }

        public void ExecuteSqlQuery(string query, params object[] parameters)
        {
            Context.Database.ExecuteSqlCommand(query, parameters);
        }
    }
}
