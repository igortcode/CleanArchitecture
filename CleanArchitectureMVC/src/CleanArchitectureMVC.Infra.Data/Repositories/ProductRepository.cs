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
            return await _dbSet.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            //eager loading
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
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
