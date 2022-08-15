using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            // add some categories
            _categories = new List<Category>();
            _categories.Add(new Category()
            {
                CategoryId = 1,
                 Name = "Books",
                 Description = "Books category example"
            });
            _categories.Add(new Category()
            {
                CategoryId = 2,
                Name = "Notebooks",
                Description = "Notebooks category example"
            });
            _categories.Add(new Category()
            {
                CategoryId = 3,
                Name = "Sports",
                Description = "Sports category example"
            });
        }
        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }
    }
}
