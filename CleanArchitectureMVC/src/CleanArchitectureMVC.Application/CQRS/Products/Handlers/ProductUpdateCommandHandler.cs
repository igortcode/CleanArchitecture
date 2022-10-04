using CleanArchitectureMVC.Application.CQRS.Products.Commands;
using CleanArchitectureMVC.Domain.Entities;
using CleanArchitectureMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Application.CQRS.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetAsync(request.Id);
            if (entity is null)
                throw new ApplicationException("Entity could not be found");

            entity.Update(request.Name, request.Description, request.Price ,request.Stock ,request.Image, request.CategoryId);

            return await _productRepository.Update(entity);
        }
    }
}
