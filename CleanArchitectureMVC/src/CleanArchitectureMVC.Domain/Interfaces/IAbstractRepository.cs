using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Domain.Interfaces
{
    public interface IAbstractRepository <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task<T> DeleteAsync(T entity);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    }
}
