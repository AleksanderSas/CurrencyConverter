using System;

namespace CurrencyService.Services
{
    class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        { }
    }
}
