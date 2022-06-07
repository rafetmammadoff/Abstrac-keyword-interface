using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Product
    {
        public Product()
        {
            _mainOrderNo++;
            _orderNo = _mainOrderNo;
        }
        public string Name;
        public string No;
        public int Price;
        public int Count;
        static private int _mainOrderNo;
        private int _orderNo;
        public void ShowInfo()
        {
            
            Console.WriteLine(value: $"Name-{Name} No-{No} Count-{Count} Price-{Price}");
        }

    }
}
