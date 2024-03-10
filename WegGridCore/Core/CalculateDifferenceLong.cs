using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Core
{
    public class CalculateDifferenceLong : ICalculate
    {
        public double Calculate(double LongFence, double LongGrid)
        {
            double diff = Math.Round(LongGrid - LongFence,2);
            return diff;
        }
    }
}
