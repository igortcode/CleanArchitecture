using CleanArchitectureMVC.Domain.Validation;

namespace CleanArchitectureMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; } //Não faz parte do domínio
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image, id);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image = null, int? id = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimun 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimun 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid Price value.");

            DomainExceptionValidation.When(stock < 0, "Invalid Stock value.");

            if(image != null)
                DomainExceptionValidation.When(image.Length > 250, "Invalid Image name, too long, maximum 250 characters");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

            if(id != null)
            {
                DomainExceptionValidation.When(id.Value <= 0, "Invalid Id value");
                Id = id.Value;
            }
        }
    }
}
