using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Application.Interfaces
{
    public interface IAbstractService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Remove(int? id);
        Task Add(T entity);
        Task Update(T entity);
    }
}
