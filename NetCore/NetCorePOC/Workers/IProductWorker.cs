using NetCorePOC.Model;

namespace NetCorePOC.Workers
{
    public interface IProductWorker
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductByName(string name);

        Product GetProductById(int id);

        void AddProduct(Product product);

        IEnumerable<Product> UpdateProduct(Product product);
        
    }
}