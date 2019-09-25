using NUnit.Framework;
using Server.Services;

namespace CurrencyServiceTest
{
    class CurrencyConverterServiceTest
    {
        private CurrencyConverterService _target;

        [SetUp]
        public void Setup()
        {
            _target = new CurrencyConverterService();
        }

        [TestCase("0", "zero dollars")]
        [TestCase("1", "one dollar")]
        [TestCase("25,1", "twenty-five dollars and ten cents")]
        [TestCase("0,01", "zero dollars and one cent")]
        [TestCase("45100", "forty-five thousand one hundred dollars")]
        [TestCase("999999999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void WhenInputHasCorrectFormat_CallConverter_ReceiveErrorMessage(string input, string output)
        {
            var result = _target.ConvertValue(input);

            Assert.AreEqual(output, result);
        }
    }
}
