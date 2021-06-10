using System.Collections.Generic;
using Newtonsoft.Json;
using Tasks;
using Xunit;

namespace Tests
{
    public class SumHelperTests
    {
        private readonly SumHelper _sumHelper;

        public SumHelperTests()
        {
            _sumHelper = new SumHelper();
        }

        [Theory]
        [InlineData(2, new[] {3, 1, 8, 5, 4}, false)]
        [InlineData(10, new[] {3, 1, 8, 5, 4}, true)]
        [InlineData(7, new[] {3, 1, 8, 5, 4}, true)]
        [InlineData(18, new[] {3, 1, 8, 5, 4}, true)]
        [InlineData(14, new[] {3, 1, 8, 5, 4}, true)]
        [InlineData(3, new[] {3, 1, 8, 5, 4}, true)]
        public void GetOrderCombinationsTest(int number, int[] numbers, bool expected)
        {
            //Arrange
            //Act
            var result = _sumHelper.IsNumberCanBeSumOfNumbers(number, numbers);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}