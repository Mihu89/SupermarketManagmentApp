﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.ProductsUseCases;

namespace Plugins.DataStore.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        //private List<Transaction> _transactions = new List<Transaction>();
        private List<Transaction> _transactions;
        public TransactionRepository()
        {
            _transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAll(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _transactions;
            }
            else
            {
                return _transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _transactions.Where(x => x.TimeStamp.Date == date.Date);
            }
            else
            {
                return _transactions.Where(
                    x => x.TimeStamp.Date == date.Date
                    && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Save(string cashierName, int productId, decimal price, int quantity)
        {
            int transactionId = 1;
            if (_transactions != null && _transactions.Count > 0)
            {
                int maxId = _transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }

            _transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                Quantity = quantity,
                CashierName = cashierName
            });
        }
    }
}
