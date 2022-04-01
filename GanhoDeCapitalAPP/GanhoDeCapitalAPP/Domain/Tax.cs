using GanhoDeCapitalAPP.Domain.Interfaces;
using GanhoDeCapitalAPP.Util;

namespace GanhoDeCapitalAPP.Domain
{
    public class Tax : ITax
    {
        public Transaction Transaction { get; }
        public Trade Trade { get; }
        public decimal TaxRate { get; }
        public Tax(Transaction transaction, Trade trade)
        {
            Transaction = transaction;
            Trade = trade;
            TaxRate = 0.2m;
        }

        public decimal CalculateTax()
        {
            if (HasTax())
            {
                var currentBalance = Trade.Balance(Transaction);
                var balanceWithoutLosses = currentBalance - Trade.Loss(Transaction);
                if(balanceWithoutLosses > 0)
                    return balanceWithoutLosses * TaxRate;
            }

            return 0m;
        }

        public bool HasTax()
        {
            return Transaction.Operation == Utils.SELL && Utils.RATE_LIMIT <= Transaction.Total() && Trade.HasProfit(Transaction);
        }
    }
}
