using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.ProductsUseCases
{
    public interface ITransactionRepository
    {
        void Save(string cashierName, int productId, decimal price, int quantity);
        IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day);
        IEnumerable<Transaction> GetAll(string cashierName);

    }
}