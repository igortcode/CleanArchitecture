using CleanArchitectureMVC.Domain.Entities;
using CleanArchitectureMVC.Domain.Interfaces;
using CleanArchitectureMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Products;
        }
        public async Task<Product> Create(Product entity)
        {
            _dbSet.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Product> GetAsync(int? id)
        {
            return await _dbSet.Include(a => a.Category).FirstAsync(a => a.Id == id.Value);
        }

        public async Task<Product> Update(Product entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
