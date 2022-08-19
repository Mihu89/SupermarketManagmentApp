using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private ICategoryRepository _categoryRepository;
        public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public Category Execute(int categoryId)
        {
           return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
