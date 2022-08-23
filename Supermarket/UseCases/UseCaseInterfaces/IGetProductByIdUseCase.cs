using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProductByIdUseCase
    {
        Product GetProductById(int productId);
    }
}