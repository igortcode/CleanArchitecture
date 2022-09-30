using AutoMapper;
using CleanArchitectureMVC.Application.DTO;
using CleanArchitectureMVC.Application.Interfaces;
using CleanArchitectureMVC.Domain.Entities;
using CleanArchitectureMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task Add(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.Create(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var entityList = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entityList);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var entity = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task Remove(int? id)
        {
            var entity =  _productRepository.GetAsync(id).Result;
            await _productRepository.DeleteAsync(entity);
        }

        public async Task Update(ProductDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _productRepository.Update(entity);
        }
    }
}
