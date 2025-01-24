using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Repositories.Fr
{
    public interface IRepository<T> where T:class
    {
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();

          T Find(T entity);
          Task<T> FindAsync(T entity);

        T AddOrUpdate(T entity);
        Task<T> AddOrUpdateAsync(T entity);

        T Delete(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
