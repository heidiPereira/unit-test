using NetCorePOC.Model;
using NetCorePOC.Workers;

namespace NetCorePOC.Services
{
    public class ProductService
    {
        private readonly IProductWorker _productWorker;

        public ProductService() : this(new ProductWorker()) { }

        public ProductService(IProductWorker productWorker)
        {
            _productWorker = productWorker ?? throw new ArgumentNullException(nameof(productWorker));;
        }

        public Product GetProductByName(string name)
        {
            return _productWorker.GetProductByName(name);
        }
        
        public ProductsSummary GetSummaryProducts()
        {
            var products = _productWorker.GetAllProducts();
            
            return new ProductsSummary { TotalProducts = products.Count() };
        }

        public void NotCoverForTest(int x) 
        {
            var boo = x + 1;
            boo = 5 + 4 + x;
        }
    }
}