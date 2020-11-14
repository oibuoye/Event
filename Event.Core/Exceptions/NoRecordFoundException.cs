using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Exceptions
{
    public class NoRecordFoundException : Exception
    {
        public NoRecordFoundException(string message) : base(message)
        {
        }

        public NoRecordFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
