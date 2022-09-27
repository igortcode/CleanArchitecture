using CleanArchitectureMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchitectureMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            //Padrao AAA => Arange, Act, Assert
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimun 3 characters");
        }

        [Fact(DisplayName = "Create Product Missing Name")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product Null Name")]
        public void CreateProduct_NullNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }


        [Fact(DisplayName = "Create Product Missing Description")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product Null Description")]
        public void CreateProduct_NullDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimun 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Stock value.");
        }

        [Fact(DisplayName = "Create Product With Long Image Name")]
        public void CreateProduct_LongImageNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, 
                "product image loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnnnnnnnnnnnnnnnnnnnnggggggggggggggggggggggggggggggggggggggggggggggggggggggg naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaammmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmeeeeeeeeeeeeeeeee");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image Name")]
        public void CreateProduct_NullImageNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,
                null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }
    }
}
