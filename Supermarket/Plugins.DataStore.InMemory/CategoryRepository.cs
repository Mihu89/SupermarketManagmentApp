using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxCategoryId = _categories.Max(x => x.CategoryId);

            category.CategoryId = maxCategoryId +1;
            _categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                _categories.Add(category);
            }
        }
    }
}
