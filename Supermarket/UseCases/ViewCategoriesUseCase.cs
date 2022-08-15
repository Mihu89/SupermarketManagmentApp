using CoreBusiness;
using System;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewCategoriesUseCase
    {
        private readonly ICategoryRepository _categoryRepository { get; }
        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public IEnumerable<Category> Execute()
        {
            return _categoryRepository.GetCategories();
        }

    }
}
