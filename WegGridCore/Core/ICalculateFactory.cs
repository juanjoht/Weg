using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Core
{
    public interface ICalculateFactory
    {
        ICalculate GetInstanceByType(CalculateType calculateType);
    }
}
