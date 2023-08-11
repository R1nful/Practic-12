using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_12
{
    internal interface IAccount <out T>
    {
        T TransferMoney(Invoice trensferInvoice, decimal trensferMoney);
    }
}
