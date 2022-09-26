using CleanArchitectureMVC.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchitectureMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidadeDomain(name);
        }

        public Category(int id, string name)
        {
            ValidadeDomain(name, id);
        }
        
        public void Update(string name)
        {
            ValidadeDomain(name);
        }
        private void ValidadeDomain(string name, int? id = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimun 3 characters");
            
            Name = name;

            if(id != null)
            {
                DomainExceptionValidation.When(id.Value <= 0, "Invalid Id value");
                Id = id.Value;
            }
        }

    }
}
