using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    internal class ProductLimitIsFilledException : Exception
    {
        public ProductLimitIsFilledException(string msg) : base(msg)
        {

        }
    }
}
