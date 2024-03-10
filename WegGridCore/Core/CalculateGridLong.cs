using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Core
{
    public class CalculateGridLong : ICalculate
    {
        public double Calculate(double LongFence, double LongGrid)
        {
            double gridAmount = Math.Ceiling(LongFence / LongGrid);
            double gridLong = gridAmount * LongGrid;
            return gridLong;
        }
    }
}
