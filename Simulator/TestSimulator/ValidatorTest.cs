using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;

namespace TestSimulator
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData(5, 1, 10, 5)]
        [InlineData(0, 1, 10, 1)]
        [InlineData(15, 1, 10, 10)]
        public void Limiter_ShouldClampValue(int value, int min, int max, int expected)
        {
            var result = Validator.Limiter(value, min, max);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Test", 5, 10, '-', "Test--")]
        [InlineData("TooLongString", 5, 8, '-', "Toolongs")]
        [InlineData("", 5, 10, '-', "-----")]
        [InlineData(null, 5, 10, '-', "-----")]
        public void Shortener_ShouldHandleVariousCases(string input, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(input, min, max, placeholder);
            Assert.Equal(expected, result);
        }
    }

}
