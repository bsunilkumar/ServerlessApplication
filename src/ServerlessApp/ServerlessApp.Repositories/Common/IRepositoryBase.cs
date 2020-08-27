using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.Common
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> SaveOrUpdateAsync(T entity); 
        //Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);   
        //Task<int> CountAll();
        //Task<int> CountWhere(Expression<Func<T, bool>> predicate);  
    }
}
