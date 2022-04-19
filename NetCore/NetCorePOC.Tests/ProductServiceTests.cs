using Xunit;
using NetCorePOC.Services;
using System.Linq;
using NetCorePOC.Model;
using NetCorePOC.Workers;
using Moq;
using System.Collections.Generic;

namespace NetCorePOC.Tests
{
    public class ProductServiceTests
    {
        ProductService _productService;
        Mock<IProductWorker> _mockProductWorker;

        public ProductServiceTests()
        {
            _mockProductWorker = new Mock<IProductWorker>();
             _productService = new ProductService(_mockProductWorker.As<IProductWorker>().Object);
        }

        [Fact]
        public void Get_Null_Product_Given_A_Name()
        {
            // Arrange
            var name = "Product 89";
            _mockProductWorker.Setup(p => p.GetProductByName(name)).Returns(null as Product);

            // Act
            var result = _productService.GetProductByName(name);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Get_Product_Given_A_Name()
        {
            // Arrange
            var name = "Boo";
            var product = new Product {
                Id = 1,
                Name = "Boo", 
                Description = "Product 1 description"
            };
            _mockProductWorker.Setup(p => p.GetProductByName(name)).Returns(product);

            // Act
            var result = _productService.GetProductByName(name);

            // Assert
            Assert.True(result.Name == product.Name);
            Assert.True(result.Description == product.Description);
        }

        [Fact]
        public void Get_Summary_Products()
        {
            // Arrange
            var products = new List<Product> {
                new Product { Id = 1, Name = "Product 1", Description = "Product 1 description" },
                new Product { Id = 2, Name = "Product 2", Description = "Product 2 description" },
            };
            _mockProductWorker.Setup(p => p.GetAllProducts()).Returns(products);

            // Act
            var result = _productService.GetSummaryProducts();

            // Assert
            Assert.True(result.TotalProducts == products.Count);
        }
        
    }
}