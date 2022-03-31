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
                return TaxRate * Transaction.Total();
            }

            return 0m;
        }

        public bool HasTax()
        {
            return Transaction.Operation == Utils.SELL && Transaction.Total() <= Utils.RATE_LIMIT && Transaction.HasProfit();
        }
    }
}
