using ClassLibrary;
using StoreApp.Exceptions;
using System;

namespace StoreApp
{
    internal class Program
    {
        static Market Market;            
        static void Main(string[] args)
        {
            Market bravo = new Market { Name = "Bravo"};
            Market = bravo;
            int input=0;                                
            bool parsable;
            do
            {
                Console.WriteLine($"{Market.Name}-ya xos geldiniz.");
                Console.WriteLine("ProductLimiti daxil edin");
                string inputStr = Console.ReadLine();
                parsable=int.TryParse(inputStr,out input); 

            } while (parsable==false || input  < 0);

            Market.ProductLimit = input;

            string select;                              
            do
            {
                Console.WriteLine("1-Mehsul elave edin");
                Console.WriteLine("2-Mehsul satin");
                Console.WriteLine("3-Mehsullara baxin");
                Console.WriteLine("4-Proqramdan cixin");
                Console.WriteLine("5-ProductLimiti deyisin");
                select = Console.ReadLine();

                SelectedProses(select);                  
                
            } while (select != "4");
        }

        static void SelectedProses(string no)
        {
            switch (no)
            {
                case "1":
                    AddedProduct();
                    break;

                case "2":
                    SelledProduct();
                    break;

                case "3":
                    ShowedProduct();                   
                    break;
                case "4":
                    break;
                case "5":
                    ChangeProductLimit();
                    break;
                default:
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Secim duzgun deyil !!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
            }
        }

        static void ChangeProductLimit()
        {
            try
            {
                string password;
                do
                {
                    Console.WriteLine("Admin parolu daxil edin : ");
                    password = Console.ReadLine();
                } while (password != "admin");
                int input = 0;
                bool parsable;
                do
                {

                    Console.WriteLine("ProductLimiti daxil edin");
                    string inputStr = Console.ReadLine();
                    parsable = int.TryParse(inputStr, out input);

                } while (parsable == false);
                Market.ProductLimit = input;
            }
            catch (ProductLimitMistakeValueException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (ProductLimitIsFilledException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }
        }
        static Product GetProductByInfo()
        {
            
            Console.WriteLine("Product adini daxil edin");
            string name = Console.ReadLine();

            Console.WriteLine("Product nomresini daxil edin");
            string no = Console.ReadLine();

            int price=AddProductPrice();
            int count=AddProductCount();

            Product product = new Product();
            product.Name = name;
            product.Price = price;
            product.Count = count;
            product.No=no;
            return product;
        }

        

        static void SellWithProductNo()
        {
                Console.WriteLine("Mehsulun nomresini daxil edin");
                string no = Console.ReadLine();
                Market.SellProduct(no);
        }

        static int AddProductPrice()
        {
            int price;
            string priceStr;
            do
            {
                Console.WriteLine("Product qiymetini daxil edin");
                priceStr = Console.ReadLine();
            } while (!int.TryParse(priceStr, out price) || price<0);
            return price;
        }
        static int AddProductCount()
        {
            int count;
            string priceStr;
            do
            {
                Console.WriteLine("Product sayini daxil edin");
                priceStr = Console.ReadLine();
            } while (!int.TryParse(priceStr, out count) || count < 0);

            return count;
        }


        static void AddProductAtMarket(Market market)
        {
            if (market.ProductLimit==0) 
                throw new ProductLimitIsFilledException("Elave etmek ucun Limit yoxdur");
            try
            {
                Product product = GetProductByInfo();
                Market.AddProduct(product);
            }
            catch (ProductByNoException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (ProductLimitIsFilledException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }
        }

        static void SellProductFromMarket(Market market)
        {
            if (market.Products.Length == 0)
            {
                throw new MarketFullEmptyException("Marketde mehsul yoxdur");
            }
            try
            {
                SellWithProductNo();
            }
            catch (NoProductAtMarketException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (ProductHasNotStockException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }
        }

        static void ShowInfo(Market market)
        {
            if (Market.Products.Length==0)
            {
                throw new MarketFullEmptyException("Gosterilecek mehsul yoxdur");
            }
            foreach (var item in market.Products)
            {
                item.ShowInfo();
            }
        }
        static void AddedProduct()
        {
            try
            {
                AddProductAtMarket(Market);
            }
            catch (ProductLimitIsFilledException exp)
            {

                Console.WriteLine(exp.Message);
            }
        }

        static void SelledProduct()
        {
            try
            {
                SellProductFromMarket(Market);
            }
            catch (MarketFullEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowedProduct()
        {
            try
            {
                ShowInfo(Market);
            }
            catch (MarketFullEmptyException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception)
            {

                Console.WriteLine("Bilinmedik bir xeta bas verdi");
            }
        }
    } 
}
