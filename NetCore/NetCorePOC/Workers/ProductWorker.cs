using NetCorePOC.Model;

namespace NetCorePOC.Workers
{
    public class ProductWorker : IProductWorker
    {
        private IEnumerable<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Product 1 description" },
            new Product { Id = 2, Name = "Product 2", Description = "Product 2 description" },
            new Product { Id = 3, Name = "Product 3", Description = "Product 3 description" },
            new Product { Id = 4, Name = "Product 4", Description = "Product 4 description" },
            new Product { Id = 5, Name = "Product 5", Description = "Product 5 description" },
            new Product { Id = 6, Name = "Product 6", Description = "Product 6 description" },
            new Product { Id = 7, Name = "Product 7", Description = "Product 7 description" },
        }; 

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductByName(string name) 
            => _products.FirstOrDefault(p => p.Name.Contains(name));

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            throw new NotImplementedException("Boo");
        }

        public IEnumerable<Product> UpdateProduct(Product product)
        {
            var productToUpdate = _products.FirstOrDefault(p => p.Id == product.Id);
            productToUpdate.Description = product.Description;
            productToUpdate.Name = product.Name;

            return _products;
        }
    }
}