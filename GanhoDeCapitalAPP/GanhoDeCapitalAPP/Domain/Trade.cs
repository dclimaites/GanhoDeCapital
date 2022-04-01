using GanhoDeCapitalAPP.Domain.Interfaces;
using GanhoDeCapitalAPP.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GanhoDeCapitalAPP.Domain
{
    public class Trade : ITrade
    {

        LinkedList<Transaction> Transactions { get; }

        public Trade(IEnumerable<Transaction> transactions)
        {
            Transactions = new LinkedList<Transaction>(transactions);
        }

        public decimal CalculateAveragePrice(Transaction transaction)
        {
            var node = this.Transactions.Find(transaction);
            IEnumerable<Transaction> purchases = Enumerable.Empty<Transaction>();
            do
            {
                var previousTransaction = node.Value;
                if (previousTransaction.Operation == Utils.BUY)
                    purchases = purchases.Append(previousTransaction);

                node = node.Previous;
            }
            while (node != null);
            return Math.Round(purchases.Sum(item => item.Total()) / purchases.Sum(item => item.Quantity), 2);
        }

        public decimal Balance(Transaction transaction) => transaction.Total() - (CalculateAveragePrice(transaction) * transaction.Quantity);
        public bool HasProfit(Transaction transaction) => transaction.UnitCost > CalculateAveragePrice(transaction);
        //public decimal Loss(Transaction transaction) => HasProfit(transaction) ? 0 : transaction.Total();
        public decimal Loss(Transaction transaction)
        {
            var node = this.Transactions.Find(transaction);
            IEnumerable<Transaction> purchases = Enumerable.Empty<Transaction>();
            decimal loss = 0;
            do
            {
                var trans = node.Value;
                //if (previousTransaction.Operation == Utils.BUY)
                //    purchases = purchases.Append(previousTransaction);
                var currentBalance = Balance(trans);
                if (currentBalance < 0)
                    loss -= currentBalance;
                else
                    loss += currentBalance;
                node = node.Previous;
            }
            while (node != null);

            if (loss > 0)
                return 0;

            return loss;
        }
    }
}
