using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_12
{
    internal interface ITransaction<in T>
    {
        void AddBalanse(T sum);
    }
}
