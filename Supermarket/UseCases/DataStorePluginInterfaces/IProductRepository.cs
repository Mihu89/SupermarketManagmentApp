using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void Update(Product product);
        Product GetProductById(int productId);
        void DeleteProduct(int productId);
        IEnumerable<Product> GetProductByCategoryId(int categoryId);
    }
}
