using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AppDomain.Models;
using AppDomain.Models.DTO_s;
using AppDomain.Response;
using DataAccess.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Moq;
using Service.Implementations;
using Service.Interfaces;
using WebApi.Controllers;
using Xunit;
using Xunit.Sdk;

namespace TestApp
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Random rand = new();

        public ProductServiceTests()
        {
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnProduct()
        {
           // Arrange
           var expectedProduct = CreateRandomProduct();

           _productRepositoryMock.Setup(x => x.Get(expectedProduct.Id))
               .ReturnsAsync(expectedProduct);

           // Act
           var actualResponse = await _productService.GetProduct(expectedProduct.Id);
           var actualData = actualResponse.Data;

           // Assert 
           actualData.Should().BeEquivalentTo(expectedProduct);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnProducts()
        {
            //Arrange
            var expectedProducts = new List<Product>();
            expectedProducts.Add(CreateRandomProduct());
            expectedProducts.Add(CreateRandomProduct());
            expectedProducts.Add(CreateRandomProduct());
            // ------OR-------
            //var expectedProduct = new[]
            //{
            //CreateRandomProduct(),
            //CreateRandomProduct(),
            //CreateRandomProduct()
            //};

            _productRepositoryMock.Setup(r => r.GetAll())
                .ReturnsAsync(expectedProducts);

            //Act
            var actualResponse = await _productService.GetProducts();
            var actualData = actualResponse.Data;

            //Assert
            actualData.Should().BeEquivalentTo(expectedProducts);
        }

        [Fact]
        public async Task AddProduct_ShouldReturnCreatedProduct()
        {
            //Arrange
            var expectedProduct = CreateRandomProduct();
            _productRepositoryMock.Setup(repo => repo.Add(expectedProduct))
                .ReturnsAsync(expectedProduct);
            //Act
            var actualResponse = await _productService.AddProduct(expectedProduct);
            var actualData = actualResponse.Data; // hz why null 

            //Assert
            
            actualData.Id.Should().NotBeEmpty();

        } 

        [Fact]
        public async Task UpdateProduct_ShouldReturnUpdatedProduct()
        {
            //Arrange
            var existingProduct = CreateRandomProduct();
            _productRepositoryMock.Setup(repo => repo.Get(It.IsAny<Guid>()))
                .ReturnsAsync(existingProduct);

            var productId = existingProduct.Id;
            var productToUpd = new Product()
            {
                Id = productId,
                Name = Guid.NewGuid().ToString(),
                Price = existingProduct.Price + 123
            };
            
            //Act
            var actualResponse = await _productService.EditProduct(productId, productToUpd);
            var actualData = actualResponse.Data; // hz why null 

            //Assert
            actualData.Should().BeEquivalentTo(productToUpd);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnNoContent()
        {
            //Arrange
            var existingProduct = CreateRandomProduct();
            _productRepositoryMock.Setup(repo => repo.Get(It.IsAny<Guid>()))
                .ReturnsAsync(existingProduct);
            //Act
            var actualResponse = await _productService.DeleteProduct(existingProduct.Id);

            //Assert
            actualResponse.Data.Should().BeTrue();
        }


        private Product CreateRandomProduct()
        {
            var categories = new List<Category>();
            var orders = new List<Order>();
            categories.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString()
            });
           
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Price = rand.Next(10000),
                Categories = categories,
                Orders = orders
            };
        }
    }
}
