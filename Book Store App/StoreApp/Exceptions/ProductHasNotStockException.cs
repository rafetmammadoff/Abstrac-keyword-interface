using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    public class ProductHasNotStockException : Exception
    {
        public ProductHasNotStockException( string message) : base(message)
        {

        }
    }
}
