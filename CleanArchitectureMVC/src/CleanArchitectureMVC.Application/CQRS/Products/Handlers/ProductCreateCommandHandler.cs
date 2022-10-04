using CleanArchitectureMVC.Application.CQRS.Products.Commands;
using CleanArchitectureMVC.Domain.Entities;
using CleanArchitectureMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureMVC.Application.CQRS.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product(request.Name, request.Description, 
                request.Price, request.Stock, request.Image);

            if (entity is null)
                throw new ApplicationException("Error creating entity.");

            entity.CategoryId = request.CategoryId;
            return await _productRepository.Create(entity);
        }
    }
}
