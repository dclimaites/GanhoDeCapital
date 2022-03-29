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
        Transaction Transaction { get; }

        public Tax(Transaction transaction)
        {
            Transaction = transaction;
        }
        public decimal CalculateTax()
        {
            throw new NotImplementedException();
        }
    }
}
