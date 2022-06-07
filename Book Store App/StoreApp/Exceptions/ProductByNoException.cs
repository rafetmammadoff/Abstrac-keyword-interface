using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    public class ProductByNoException : Exception
    {
        public ProductByNoException(string message) : base(message)
        {

        }
    }
}
