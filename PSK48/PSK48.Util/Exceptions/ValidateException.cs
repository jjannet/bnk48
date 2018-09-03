using System;
using System.Collections.Generic;
using System.Text;

namespace PSK48.Util.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException()
        {
        }

        public ValidateException(string message)
        : base(message)
        {
        }

        public ValidateException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
