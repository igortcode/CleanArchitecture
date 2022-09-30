using CleanArchitectureMVC.Domain.Entities;
using MediatR;

namespace CleanArchitectureMVC.Application.CQRS.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
