using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    public class ProductLimitMistakeValueException : Exception
    {
        public ProductLimitMistakeValueException(string message) : base(message)
        {

        }
    }
}
