using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Exceptions
{
    public class NoProductAtMarketException : Exception
    {
        public NoProductAtMarketException( string msg) : base(msg)
        {

        }
    }
}
