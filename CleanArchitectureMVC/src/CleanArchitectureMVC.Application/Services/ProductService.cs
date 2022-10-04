using AutoMapper;
using CleanArchitectureMVC.Application.CQRS.Products.Commands;
using CleanArchitectureMVC.Application.CQRS.Products.Queries;
using CleanArchitectureMVC.Application.DTO;
using CleanArchitectureMVC.Application.Interfaces;
using CleanArchitectureMVC.Domain.Entities;
using CleanArchitectureMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Add(ProductDTO dto)
        {
            var command = _mapper.Map<ProductCreateCommand>(dto);
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var query = new GetProductsQuery();

            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            var entity = await _mediator.Send(query);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task Remove(int? id)
        {
            var command = new ProductRemoveCommand(id.Value);
            await _mediator.Send(command);
        }

        public async Task Update(ProductDTO dto)
        {
            var command = _mapper.Map<ProductUpdateCommand>(dto);
            await _mediator.Send(command);
        }
    }
}
