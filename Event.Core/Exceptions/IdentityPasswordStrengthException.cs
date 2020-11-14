using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.Core.Exceptions
{
    public class IdentityPasswordStrengthException : Exception
    {
        public IdentityPasswordStrengthException(string message) : base(message)
        {
        }

        public IdentityPasswordStrengthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
