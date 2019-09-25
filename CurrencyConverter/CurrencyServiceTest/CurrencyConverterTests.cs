using Moq;
using NUnit.Framework;
using Server;
using Server.Services;

namespace CurrencyServiceTest
{
    public class CurrencyConverterTests
    {
        private CurrencyConverter _target;
        private string _returnValue = "zero dollars";

        [SetUp]
        public void Setup()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockedCurrencyService= new Mock<ICurrencyConverterService>();
            mockedCurrencyService.Setup(x => x.ConvertValue(It.IsAny<string>())).Returns(_returnValue);

            _target = new CurrencyConverter(mockedLogger.Object, mockedCurrencyService.Object);
        }

        [TestCase("aa 123")]
        [TestCase("123.090")]
        [TestCase(".0")]
        [TestCase("123.")]
        [TestCase("123..9")]
        [TestCase("   ")]
        [TestCase(null)]
        public void WhenInputHasWrongFormat_CallConverter_ReceiveErrorMessage(string input)
        {
            var result = _target.Convert(input);

            Assert.IsNotNull(result.ErrorMessage);
            Assert.IsNull(result.Result);
        }

        [TestCase("0")]
        [TestCase("1")]
        [TestCase("25,1")]
        [TestCase("0,01")]
        [TestCase("45 100")]
        [TestCase("999 999 999,99")]
        public void WhenInputIsCorrect_CallConverter_ReceiveResulte(string input)
        {
            var result = _target.Convert(input);

            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(_returnValue, result.Result);
        }
    }
}