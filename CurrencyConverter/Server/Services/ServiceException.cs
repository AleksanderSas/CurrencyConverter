using System;

namespace Server
{
    class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        { }
    }
}
