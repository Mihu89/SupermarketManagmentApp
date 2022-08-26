namespace UseCases.ProductsUseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, int quantity);
    }
}