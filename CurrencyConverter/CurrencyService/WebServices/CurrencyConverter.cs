using CurrencyService.Logger;
using CurrencyService.Services;
using System;
using System.Text.RegularExpressions;

namespace CurrencyService
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly ILogger _log;
        private readonly ICurrencyConverterService _currencyConverterService;

        public CurrencyConverter(ILogger logger, ICurrencyConverterService currencyConverterService)
        {
            _log = logger;
            _currencyConverterService = currencyConverterService;
        }

        public RequestResult Convert(string input)
        {
            _log.LogInfo($"{nameof(CurrencyConverter.Convert)} called with argument: {input}");
            if(string.IsNullOrWhiteSpace(input))
            {
                return new RequestResult { ErrorMessage = "Input cannot be empty" };
            }

            input = TrimAndValidate(input);
            if (input != null)
            {
                try
                {
                    return new RequestResult { Result = _currencyConverterService.ConvertValue(input) };
                }
                catch (ServiceException ex)
                {
                    return new RequestResult { ErrorMessage = ex.Message };
                }
                catch(Exception ex)
                {
                    _log.LogInfo($"{nameof(CurrencyConverter.Convert)} critical error: {ex.Message}");
                    return new RequestResult { ErrorMessage = "Internal error" };
                }
            }
            return new RequestResult { ErrorMessage = "Input is invalid" };
        }

        private static string TrimAndValidate(string input)
        {
            input = Regex.Replace(input, "\\s+", "");
            if (!Regex.IsMatch(input, "^\\d+(,\\d\\d?)?$"))
            {
                return null;
            }
            return input;
        }

       
    }
}
