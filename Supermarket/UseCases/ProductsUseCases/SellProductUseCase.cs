using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productRepository = productRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, int quantityToSell)
        {
            var productToSell = _productRepository.GetProductById(productId);
            if (productToSell == null) return;
            // change product quantity
            productToSell.Quantity -= quantityToSell;

            // update product
            _productRepository.Update(productToSell);
            _recordTransactionUseCase.Execute(cashierName, productId, quantityToSell);
        }
    }
}
