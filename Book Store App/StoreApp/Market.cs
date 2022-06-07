using ClassLibrary;
using StoreApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    internal class Market : IStore
    {
        public string Name { get; set; }

        private int _totalInCome=0;
        private Product[] _products=new Product[0];
        private int _productLimit = 0;
        public Product[] Products
        {
            get { return _products; }
        }
        public int ProductLimit                       
        {
            get { return _productLimit; }
            set
            {
                if (value < 0)
                {
                    throw new ProductLimitMistakeValueException("Product limit menfi eded ola bilmez");
                }
                if (value<_products.Length)
                {
                    throw new ProductLimitIsFilledException("Product limit mehsullarin sayindan az ola bilmez");
                }
                _productLimit = value;
               
            }
        }

        public int TotalIncome
        {
            get => _totalInCome;
        }

        public void AddProduct(Product product)
        {
            if (_products.Length >= ProductLimit)
            {
                throw new ProductLimitIsFilledException("Mehsul elave etmek ucun limit kifayet deyil");
            }
            if (!CheckProductNo(product))
            {
                throw new ProductByNoException("Bu nomreli product artiq elave edilib");
            }

            Array.Resize(ref _products, _products.Length + 1);
            _products[_products.Length - 1] = product;



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

        public void SellProduct(string no) 
        {
          Product product = FindProductByNo(no);
            if (product == null)
            {
                throw new NoProductAtMarketException($"{no} nomreli mehsul tapilmadi");
            }
            if (product.Count < 1)
            {
                throw new ProductHasNotStockException("Mehsul stokda bitmisdir!!");
            }

            _totalInCome+=product.Price;
            product.Count--;


        }

        public Product FindProductByNo(string no)
        {
            Product product = null;

            foreach (var item in _products)
            {
                if (item.No==no)
                {
                    product = item;
                }
            }
            return product;
        }
    }
}
