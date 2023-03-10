using System;

namespace StringCalc
{
    public class StringCalculator_Add
    {
        private StringCalculator _calculator = new StringCalculator();

        [Fact]
        public void Returns0GivenEmptyString()
        {
            var result = _calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1",1)]
        [InlineData("2",2)]
        public void ReturnsNumberGivenStringWithOneNumber(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void ReturnsSumGivenStringWithTwoCommaSeperatedNumbers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("2,3,4", 9)]
        public void ReturnsSumGivenStringWithThreeCommaSeperatedNumbers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("1,2\n3", 6)]
        public void ReturnsSumGivenStringWithThreeCommaOrNewLineSeperatedNumbers(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]

        public void ReturnsSumGivenStringWitCostumDelimiter(string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]

        public void TrowsGivenNegativeInputs(string numbers, string expectedMessage)
        {

            Action action = () => _calculator.Add(numbers);
            var ex = Assert.Throws<Exception>(action);
            
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedMessage, ex.Message);
        }
    }
}