using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ProductsUseCases;

namespace Plugins.DataStore.Sql.Repos
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SuperMarketDbContext _dbContext;

        public TransactionRepository(SuperMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public void AddTransaction(Transaction transaction)
        //{
        //    _dbContext.Transactions.Add(transaction);
        //    _dbContext.SaveChanges();
        //}

        //public void DeleteTransaction(int TransactionId)
        //{
        //    var Transaction = _dbContext.Transactions.Find(TransactionId);
        //    if (Transaction == null)
        //    {
        //        return;
        //    }
        //    _dbContext.Transactions.Remove(Transaction);
        //    _dbContext.SaveChanges();
        //}

        //public IEnumerable<Transaction> GetTransactions()
        //{
        //    return _dbContext.Transactions.ToList();
        //}

        //public Transaction GetTransactionById(int TransactionId)
        //{
        //    return _dbContext.Transactions.Find(TransactionId);
        //}

        public void Save(string cashierName, int productId, string productName, decimal price, int beforeQuantity, int soldQuantity)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                BeforeQuantity = beforeQuantity,
                Quantity = soldQuantity,
                CashierName = cashierName
            };

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _dbContext.Transactions.Where(x => x.TimeStamp.Date == date).ToList();
            }
            else
            {
                return _dbContext.Transactions.Where(x =>
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp.Date == date).ToList();
            }
        }

        public IEnumerable<Transaction> GetAll(string cashierName)
        {
            return _dbContext.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _dbContext.Transactions.Where(x => x.TimeStamp >= startDate &&
                x.TimeStamp <= endDate).ToList();
            }
            else
            {
                return _dbContext.Transactions.Where(x =>
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp >= startDate &&
               x.TimeStamp <= endDate).ToList(); // or x.TimeStamp <= endDate.AddDays(1).Date
            }
        }
    }
}

