using Xunit;
using NetCorePOC.Workers;
using System.Linq;
using NetCorePOC.Model;

namespace NetCorePOC.Tests;

public class ProductWorkerTests
{
    ProductWorker _productWorker;

    public ProductWorkerTests()
    {
        _productWorker = new ProductWorker();
    }

    [Fact]
    public void Get_All_Products()
    {
        // Act
        var products = _productWorker.GetAllProducts();

        // Assert
        Assert.NotNull(products);
        Assert.True(products.Count() > 0);
        Assert.True(products.Any(p => p.Name.Contains("Product 1")));
    }

    [Fact]
    public void Update_Product()
    {
        // Arrange
        var description = "Product 1";
        var name = "Boo";
        var product = new Product { Id = 1, Name = name, Description = description };

        // Act
        var products = _productWorker.UpdateProduct(product);

        // Assert
        Assert.True(products.Any(p => p.Description == description && p.Name == name));
    }
    
}