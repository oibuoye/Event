using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Exceptions
{
    public class RecordAlreadyExistException : Exception
    {
        public RecordAlreadyExistException(string message) : base(message)
        {
        }

        public RecordAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }    
}
