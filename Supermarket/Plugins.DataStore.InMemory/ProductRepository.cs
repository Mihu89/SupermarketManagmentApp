﻿using CoreBusiness;
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
                    Price = 5
                },
                 new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Product 2",
                    Quantity = 20,
                    Price = 25
                },
                 new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Amintiri din Copilarie",
                    Quantity = 30,
                    Price = 40
                }
            };
        }
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

    }
}