using GanhoDeCapitalAPP.Domain.Interfaces;

namespace GanhoDeCapitalAPP.Domain
{
    public class Transaction : ITransaction
    {
        public Transaction(string operation, decimal unitCost, int quantity, decimal averagePrice)
        {
            Operation = operation;
            UnitCost = unitCost;
            Quantity = quantity;
            AveragePrice = averagePrice;
        }

        /// <summary>
        /// Identifica o tipo de operação Buy/Sell
        /// </summary>
        public string Operation { get;}
        /// <summary>
        /// Custo unitário da transação
        /// </summary>
        public decimal UnitCost { get; }
        public int Quantity { get; }
        public decimal AveragePrice { get; }
        public decimal Total() => UnitCost * Quantity;
        public decimal Balance() => Total() - AveragePrice * Quantity;
        public bool HasProfit() => UnitCost > AveragePrice;
    }
}
