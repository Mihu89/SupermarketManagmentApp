using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SuperMarketDbContext _dbContext;

        public CategoryRepository(SuperMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            if (category == null)
            {
                return;
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
            _dbContext.SaveChanges();
        }
    }
}
