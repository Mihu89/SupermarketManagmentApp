using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly SuperMarketDbContext _dbContext;

        public ProductRepository(SuperMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete == null)
            {
                return;
            }
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _dbContext.Products.Where(x => x.CategoryId ==categoryId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void Update(Product product)
        {
           var productToUpdate = _dbContext.Products.Find(product.ProductId);
            if (productToUpdate == null)
            {
                return; // if you want to insert then add proper implementation
            }
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;

            _dbContext.SaveChanges();
        }
    }
}
