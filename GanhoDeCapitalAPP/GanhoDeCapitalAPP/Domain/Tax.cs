using GanhoDeCapitalAPP.Domain.Interfaces;
using GanhoDeCapitalAPP.Util;

namespace GanhoDeCapitalAPP.Domain
{
    public class Tax : ITax
    {
        public Transaction Transaction { get; }
        public decimal AveragePrice { get; }
        public decimal TaxRate { get; }
        public Tax(Transaction transaction, decimal averagePrice)
        {
            Transaction = transaction;
            AveragePrice = averagePrice;
            TaxRate = 0.2m;
        }

        public decimal CalculateTax()
        {
            if (HasTax())
            {
                return TaxRate * Transaction.Balance();
            }

            return 0m;
        }

        public bool HasTax()
        {
            return Transaction.Operation == Utils.SELL && Utils.RATE_LIMIT <= Transaction.Total() && Transaction.HasProfit();
        }
    }
}
