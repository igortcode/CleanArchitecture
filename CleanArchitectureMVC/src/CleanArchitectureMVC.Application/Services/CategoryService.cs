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
    internal class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task Add(CategoryDTO dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.Create(entity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var entityList = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(entityList);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = _categoryRepository.GetAsync(id).Result;
            await _categoryRepository.DeleteAsync(entity);
        }

        public async Task Update(CategoryDTO dto)
        {
            var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.Update(entity);
        }
    }
}
