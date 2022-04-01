using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.Domain.Interfaces
{
    //Ou seria Pregão?
    public interface ITrade
    {
        decimal CalculateAveragePrice(Transaction transaction);
    }
}
