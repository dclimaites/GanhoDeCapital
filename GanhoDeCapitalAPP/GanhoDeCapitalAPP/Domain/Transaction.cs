using GanhoDeCapitalAPP.Domain.Interfaces;

namespace GanhoDeCapitalAPP.Domain
{
    public class Transaction : ITransaction
    {
        public Transaction(string operation, decimal unitCost, int quantity)
        {
            Operation = operation;
            UnitCost = unitCost;
            Quantity = quantity;
        }

        /// <summary>
        /// Identifica o tipo de operação Buy/Sell
        /// </summary>
        public string Operation { get;}
        /// <summary>
        /// Custo unitário da transação
        /// </summary>
        public decimal UnitCost { get; }
        /// <summary>
        /// Quantidade da transação
        /// </summary>
        public int Quantity { get; }
        public decimal Total() => UnitCost * Quantity;
    }
}
