using GanhoDeCapitalAPP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.Domain
{
    public class Tax : IOperation
    {
        IList<Transaction> Transactions { get; }

        public Tax(IEnumerable<Transaction> transaction)
        {
            Transactions = transaction.ToList();
        }
        public decimal CalculateTax()
        {
            throw new NotImplementedException();
        }

        public decimal CalculateAveragePrice()
        {
            var purchases = this.Transactions.Where(item => item.Operation == "buy");
            return Math.Round(purchases.Sum(item => item.Quantity * item.UnitCost) / purchases.Sum(item => item.Quantity), 2);
        }
    }
}
