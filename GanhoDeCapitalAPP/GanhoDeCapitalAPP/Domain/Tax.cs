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

        public decimal CalculatePM()
        {
            return this.Transactions.Sum(item => item.Quantity * item.UnitCost) / this.Transactions.Sum(item => item.Quantity);
        }
    }
}
