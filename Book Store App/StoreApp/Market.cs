using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    internal class Market : IStore
    {
        private int _totalInCome=0;
        private Product[] _products=new Product[0];
        public Product[] Products
        {
            get { return _products; }
        }
        public int ProductLimit { get; set; }

        public int TotalIncome
        {
            get => _totalInCome;
        }

        public void AddProduct(Product product)
        {   
            if (_products.Length < ProductLimit && CheckProductNo(product))
            {   
                Array.Resize(ref _products, _products.Length + 1);
                _products[_products.Length - 1] = product;
            }
        }

        public bool CheckProductNo(Product product)
        {
            if (_products.Length>0)
            {
                for (int i = 0; i < _products.Length; i++)
                {
                    if (_products[i].No == product.No)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public void SellProduct(string no) //10,11,12
        {
            for (int i = 0; i < _products.Length; i++)
            {
                if (_products[i].No == no && _products[i].Count>0)
                {
                    _totalInCome += _products[i].Price;
                    _products[i].Count--;
                    Console.WriteLine($"Mehsul satildi. Stokda {_products[i].Count} eded . Kassa - {_totalInCome} AZN");
                    return;
                }
                else if (_products[i].No == no && _products[i].Count == 0)
                {
                    Console.WriteLine("Mehsul stokda bitib");
                    return;
                }
                
            }
            Console.WriteLine("Mehsul satisda yoxdur.");
            return;
        }
    }
}
