using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message) : base(message)
        {
        }

        public InvalidDateFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
