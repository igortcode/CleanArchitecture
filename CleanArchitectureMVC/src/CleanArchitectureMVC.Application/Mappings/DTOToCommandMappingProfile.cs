using AutoMapper;
using CleanArchitectureMVC.Application.CQRS.Products.Commands;
using CleanArchitectureMVC.Application.DTO;

namespace CleanArchitectureMVC.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
