using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> where);
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
