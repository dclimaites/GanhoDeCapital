using GanhoDeCapitalAPP.Domain.Interfaces;
using GanhoDeCapitalAPP.Util;

namespace GanhoDeCapitalAPP.Domain
{
    public class Tax : ITax
    {
        public Transaction Transaction { get; }
        public decimal AveragePrice { get; }
        public decimal Losses { get; }
        public decimal TaxRate { get; }
        public Tax(Transaction transaction, decimal averagePrice, decimal losses)
        {
            Transaction = transaction;
            AveragePrice = averagePrice;
            Losses = losses;
            TaxRate = 0.2m;
        }

        public decimal CalculateTax()
        {
            if (HasTax())
            {
                var currentBalance = Transaction.Balance();
                var balanceWithoutLosses = currentBalance - Losses;
                if(balanceWithoutLosses > 0)
                    return balanceWithoutLosses * TaxRate;
            }

            return 0m;
        }

        public bool HasTax()
        {
            return Transaction.Operation == Utils.SELL && Utils.RATE_LIMIT <= Transaction.Total() && Transaction.HasProfit();
        }
    }
}
