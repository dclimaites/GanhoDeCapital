using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanhoDeCapitalAPP.Domain.Interfaces
{
    public interface ITransaction
    {
        decimal Total();
        decimal Balance();
    }
}
