using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Core.Exceptions
{
    public class TokenExpirationException : Exception
    {
        public TokenExpirationException(string message) : base(message)
        {
        }

        public TokenExpirationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}