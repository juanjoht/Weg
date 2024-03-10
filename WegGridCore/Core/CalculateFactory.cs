using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WegGridCore.Core
{
    public class CalculateFactory : ICalculateFactory
    {
        private Dictionary<CalculateType, ICalculate> _calculateByType;

        public CalculateFactory(CalculateGridLong calculateGridLong, CalculateDifferenceLong calculateDifferenceLong, CalculateAmountGrid calculateAmountGrid)
        {
            _calculateByType = new()
            {
                { CalculateType.TotalGrid, calculateGridLong },
                { CalculateType.Difference, calculateDifferenceLong },
                 { CalculateType.AmountGrid, calculateAmountGrid },
            };
        }

        public ICalculate GetInstanceByType(CalculateType calculateType) =>
        _calculateByType[calculateType];

    }
}
