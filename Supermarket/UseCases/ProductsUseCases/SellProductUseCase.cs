using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(int productId, int quantityToSell)
        {
            var productToSell = _productRepository.GetProductById(productId);
            if (productToSell == null) return;
            // change product quantity
            productToSell.Quantity -= quantityToSell;

            // update product
            _productRepository.Update(productToSell);
        }
    }
}
