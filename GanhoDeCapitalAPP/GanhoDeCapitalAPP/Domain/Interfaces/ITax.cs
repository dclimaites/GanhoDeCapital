using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.Domain.Interfaces
{
    public interface ITax
    {
        decimal CalculateTax();
        bool HasTax();
    }
}
