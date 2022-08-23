using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}