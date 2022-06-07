using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    public class MarketFullEmptyException : Exception
    {
        public MarketFullEmptyException(string no) :base(no)
        {

        }
    }
}
