using GanhoDeCapitalAPP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GanhoDeCapitalAPP.Domain
{
    public class Trade :  ITrade
    {

        IEnumerable<Transaction> Transactions { get; }

        public Trade(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
        }

        public decimal CalculateAveragePrice()
        {
            var purchases = this.Transactions.Where(item => item.Operation == "buy");
            return Math.Round(purchases.Sum(item => item.Total()) / purchases.Sum(item => item.Quantity), 2);
        }
    }
}
