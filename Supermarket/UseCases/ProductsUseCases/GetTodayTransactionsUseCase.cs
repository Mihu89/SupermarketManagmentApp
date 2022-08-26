using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.ProductsUseCases
{
    public class GetTodayTransactionsUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTodayTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return _transactionRepository.GetTransactionsByDay(cashierName, DateTime.UtcNow);
        }
    }
}
