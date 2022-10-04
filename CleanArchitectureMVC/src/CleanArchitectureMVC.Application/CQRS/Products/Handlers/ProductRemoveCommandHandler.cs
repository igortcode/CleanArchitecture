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
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetAsync(request.Id);

            if (entity is null)
                throw new ApplicationException("Product coud not be found");

            return await _productRepository.DeleteAsync(entity);
        }
    }
}
