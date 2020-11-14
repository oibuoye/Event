using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Exceptions
{
    public class FormDuplicateBatchAndTestKitNumberException : Exception
    {
        public FormDuplicateBatchAndTestKitNumberException(string message) : base(message)
        {
        }

        public FormDuplicateBatchAndTestKitNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
