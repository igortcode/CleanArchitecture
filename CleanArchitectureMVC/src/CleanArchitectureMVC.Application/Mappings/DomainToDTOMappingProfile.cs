using AutoMapper;
using CleanArchitectureMVC.Application.DTO;
using CleanArchitectureMVC.Domain.Entities;

namespace CleanArchitectureMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
