using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessApp.Repositories.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected readonly ISession Session;
        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Session.Query<T>()
                .Where(expression);
        }

        public async Task<T> SaveOrUpdateAsync(T entity)
        {
           await Session.SaveOrUpdateAsync(entity);
            await Session.FlushAsync();
            return entity;
        }
      
    }
}
