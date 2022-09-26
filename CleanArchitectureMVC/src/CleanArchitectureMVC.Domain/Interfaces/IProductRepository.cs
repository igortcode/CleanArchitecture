using CleanArchitectureMVC.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Domain.Interfaces
{
    public interface IProductRepository : IAbstractRepository<Product>
    {
        Task<Product> GetProductCategoryAsync(int id);
    }
}
