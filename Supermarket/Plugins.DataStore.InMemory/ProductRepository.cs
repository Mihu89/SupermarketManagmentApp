using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Product 1",
                    Quantity = 10,
                    Price = 5.10m
                },
                 new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Product 2",
                    Quantity = 20,
                    Price = 25.22m
                },
                 new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Amintiri din Copilarie",
                    Quantity = 30,
                    Price = 40.80m
                }
            };
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (_products != null && _products.Count > 0)
            {
                var maxProductId = _products.Max(x => x.ProductId);

                product.ProductId = maxProductId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);    
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
            //else
            //{
            //    // add product if not found
            //    // _products.Add(product);
            //}
        }

        public Product GetProductById(int productId)
        {
            return _products.Find(x => x.ProductId == productId);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _products.FindAll(x => x.CategoryId == categoryId);
            //return _products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}