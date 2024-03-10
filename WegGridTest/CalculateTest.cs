using System.Numerics;
using WegGridCore.Core;

namespace WegGridTest
{
    public class CalculateTest
    {

        private readonly ICalculate _calculateLongGrid;
        private readonly ICalculate _calculateDiffGrid;
        private const double LONGGRID = 2.5;


        public CalculateTest()
        {
            _calculateLongGrid = new CalculateGridLong();
            _calculateDiffGrid = new CalculateDifferenceLong();
        }

        [Fact]
        public void CalculateLongGridOK()
        {
            var longGrid = _calculateLongGrid.Calculate(40.7, LONGGRID);
            Assert.NotEqual(0, longGrid);
        }

        [Fact]
        public void CalculateLongGridZero()
        {
            var longGrid = _calculateLongGrid.Calculate(0, LONGGRID);
            Assert.Equal(0, longGrid);
        }

        [Fact]
        public void CalculateLongGridNegatives()
        {
            var longGrid = _calculateLongGrid.Calculate(-1, LONGGRID);
            bool negative = longGrid <= 0;
            Assert.True(negative);
        }

        [Fact]
        public void CalculateLongGridZeroDivision()
        {
            var longGrid = _calculateLongGrid.Calculate(40,0);
            bool Expected = double.IsNaN(longGrid);
            Assert.True(Expected);
        }

        [Fact]
        public void CalculateDifferenceBetweenFenceAndGridOK()
        {
            var longGrid = _calculateLongGrid.Calculate(40.7, LONGGRID);
            double Difference = 0;
            if(longGrid != 0)
            {
                Difference = _calculateDiffGrid.Calculate(40.7, longGrid);
            }
            Assert.NotEqual(0, Difference);
        }

        
        [Fact]
        public void CalculateDifferenceBetweenFenceAndGridZero()
        {
            var Difference = _calculateDiffGrid.Calculate(0, 0); 
            Assert.Equal(0, Difference);
        }


    }
}