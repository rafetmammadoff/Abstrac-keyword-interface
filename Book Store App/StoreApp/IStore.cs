using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace StoreApp
{
    internal interface IStore
    {
        Product[] Products { get; }
        int ProductLimit { get; set; }
        int TotalIncome { get; }
        void AddProduct(Product product);
        void SellProduct(string no);
    }
}
