using System;

namespace Client.Services
{
    class ClientException : Exception
    {
        public ClientException(string message) : base(message)
        { }
    }
}
