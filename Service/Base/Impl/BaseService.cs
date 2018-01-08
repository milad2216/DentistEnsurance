using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using Repository.Base;
using System.Data.Entity.Infrastructure;
using Service._I18n;

namespace Service.Base.impl
{
    public abstract class BaseService<TModel, TRepositoryType> : IDisposable, IBaseService<TModel> where TRepositoryType : IBaseRepository<TModel> 
        where TModel : class 
    {
        public HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
  
        public TRepositoryType Repository;

        public IDbSet<TModel> Entity
        {
            get
            {
                return Repository.Entity;
            }
        }

        protected BaseService(TRepositoryType repository)
        {
            this.Repository = repository;
        }

        public async Task<CFResult> ValidateModel(object entity)
        {
            var errors = new List<object>();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            var tryValidateObject = Validator.TryValidateObject(entity, context, results, true);



            if (!tryValidateObject)
            {
                foreach (var error in results)
                    errors.Add(new { error.ErrorMessage, error.MemberNames });

                var result = new CFResult { Status = "error", Errors = errors };
                return result;
            }

            return null;
        }

        public virtual TModel ConvertArabicToPersian(TModel model)
        {
            foreach (var prop in model.GetType().GetProperties())
            {
                var val = prop.GetValue(model, null);
                if (val is string)
                {
                    //var value = val;
                    var value = ArabicCharsToPersian(val);
                    prop.SetValue(model, value, null);
                }
            }
            return model;
        }

        public virtual CFResult CreateArabic(TModel model)
        {
            var result = ValidateModel(model);
            if (result.Result != null)
                return result.Result;
            //model.CreatedBy = CurrentUser.UserName;

            Repository.Insert(model);

            if (Repository.Save() == 0)
            {
                return new CFResult { Status = "error", Message = LangUtil.Get("general_insert_failure") };
            }

            return new CFResult { Status = "success", Message = LangUtil.Get("general_create_success") };
        }
        public virtual CFResult Create(TModel model)
        {
            var result = ValidateModel(model);
            if (result.Result != null)
                return result.Result;
            model = ConvertArabicToPersian(model);
            //model.CreatedBy = CurrentUser.UserName;

            Repository.Insert(model);

            if (Repository.Save() == 0)
            {
                return new CFResult { Status = "error", Message = LangUtil.Get("general_insert_failure") };
            }

            return new CFResult { Status = "success", Message = LangUtil.Get("general_create_success")};
        }

        public virtual async Task<CFResult> CreateAsync(TModel model)
        {
            var result = await ValidateModel(model);
            if (result != null)
                return result;
            model = ConvertArabicToPersian(model);
            //model.CreatedBy = CurrentUser.UserName;

            Repository.Insert(model);
            Repository.SaveAsync();

            return new CFResult { Status = "success", Message = LangUtil.Get("general_create_success")};
        }

        public virtual CFResult Edit(TModel model, string[] blackFields = null, string[] whiteFields = null)
        {

            if (model != null)
            {
                var result = ValidateModel(model);
                if (result.Result != null)
                    return result.Result;
                model = ConvertArabicToPersian(model);

                //Repository.Entity.Attach(model);
                Repository.Update(model, blackFields, whiteFields);

                if (Repository.Save() == 0)
                {
                    return new CFResult { Status = "error", Message = LangUtil.Get("general_update_failure") };
                }
                return new CFResult { Status = "success", Message = LangUtil.Get("general_update_success") };
            }

            return new CFResult { Status = "error", Message = LangUtil.Get("general_update_failure") };
        }

        public virtual async Task<CFResult> EditAsync(TModel model, string[] blackFields = null, string[] whiteFields = null)
        {

            if (model != null)
            {
                var result = await ValidateModel(model);
                if (result != null)
                    return result;
                model = ConvertArabicToPersian(model);

                //Repository.Entity.Attach(model);
                Repository.Update(model, blackFields, whiteFields);
                Repository.SaveAsync();

                return new CFResult { Status = "success", Message = LangUtil.Get("general_update_success") };
            }

            return new CFResult { Status = "error", Message = LangUtil.Get("general_update_failure") };
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return Repository.All;
        }

        public virtual IQueryable<TModel> GetAllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {
            return Repository.AllIncluding(includeProperties);
        }

        public IEnumerable GetGridData()
        {
            return GetAll();
        }

        public virtual void Dispose()
        {
            Repository.Dispose();
        }

        public virtual List<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.FindBy(predicate);
        }
        public virtual Task<List<TModel>> FindByAsync(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.FindByAsync(predicate);
        }

        public IQueryable<TModel> Where(string predicate)
        {
            return Repository.Where(predicate);
        }

        public virtual int Count(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.Count(predicate);
        }
        public virtual Task<int> CountAsync(Expression<Func<TModel, bool>> predicate)
        {
            return Repository.CountAsync(predicate);
        }

        public int DeleteExp(Expression<Func<TModel, bool>> filterExpression)
        {
            return Repository.DeleteExp(filterExpression);
        }
        public Task<int> DeleteExpAsync(Expression<Func<TModel, bool>> filterExpression)
        {
            return Repository.DeleteExpAsync(filterExpression);
        }

        public int UpdateExp(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression)
        {
            return Repository.UpdateExp(filterExpression, updateExpression);
        }
        public Task<int> UpdateExpAsync(Expression<Func<TModel, bool>> filterExpression, Expression<Func<TModel, TModel>> updateExpression)
        {
            return Repository.UpdateExpAsync(filterExpression, updateExpression);
        }
      
        public static string ArabicCharsToPersian(object val)
        {
            var value = (string)val;
            value = value.Replace('ي', 'ی');
            value = value.Replace('ك', 'ک');
            value = value.Replace('٤', '۴');
            value = value.Replace('٥', '۵');
            value = value.Replace('٦', '٦');
            return value;
        }

        public DbRawSqlQuery<TModel> GetBySqlQuery(string query, params object[] parameters)
        {
            return Repository.GetBySqlQuery(query, parameters);
        }

        public int GetCountBySqlQuery(string query, params object[] parameters)
        {
            return Repository.GetCountBySqlQuery(query, parameters);
        }

        public void ExecuteSqlQuery(string query, params object[] parameters)
        {
            Repository.ExecuteSqlQuery(query, parameters);
        }
    }
}
