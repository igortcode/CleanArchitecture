using CleanArchitectureMVC.Domain.Entities;
using MediatR;

namespace CleanArchitectureMVC.Application.CQRS.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
