using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Core
{
    public  class CalculateAmountGrid : ICalculate
    {
        public double Calculate(double LongFence, double LongGrid)
        {
            return Math.Ceiling(LongFence / LongGrid);
        }
    }
}
