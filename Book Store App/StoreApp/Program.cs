using ClassLibrary;
using System;

namespace StoreApp
{
    internal class Program
    {
        static Market Market;             //   Yeni market --------------------------------------------
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
                parsable=IsConvertToInt(inputStr,out input); //  ProductLimit reqem daxil edilmeyibse yeniden isteyen metod--

            } while (parsable==false);

            Market.ProductLimit = input;

            string select;                                // Istifadecinin secimleri -----------------------------------
            do
            {
                Console.WriteLine("1-Mehsul elave edin");
                Console.WriteLine("2-Mehsul satin");
                Console.WriteLine("3-Mehsullara baxin");
                Console.WriteLine("4-Proqramdan cixin");
                select = Console.ReadLine();

                SelectedProses(select);                   // Secime uygun emeliyati yerine yetiren metod ----------------
                
            } while (select != "4");
        }

        static void SelectedProses(string no)
        {
            switch (no)
            {
                case "1":
                    if (Market.ProductLimit==0 || Market.Products.Length == Market.ProductLimit)
                    {
                        Console.WriteLine("Erzaq elave etmek ucun limit yoxdur!!!!!!!!!!!!!");
                    }
                    else
                    {
                        Product product = new Product();       
                        AddProductInfo(product);              // Yeni mehsulun melumatlarini daxil etmek ucun metod
                        Market.AddProduct(product);           // Melumatlar okeydirse mehsulu arraya elave eden metod
                    }
                    break;

                case "2":
                    SellWithProductNo();                  // Mehsul nomresine uygun mehsul vardirsa onu satan metod
                    break;

                case "3":
                    ShowInfo();                           // Butun mehsullar haqqinda melumatlari gosteren metod
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Secim duzgun deyil !!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
            }
        }

        static void AddProductInfo(Product product)
        {
            
            Console.WriteLine("Product adini daxil edin");
            product.Name = Console.ReadLine();

            Console.WriteLine("Product nomresini daxil edin");
            product.No = Console.ReadLine();

            bool check;
            int price=0;
            AddProductPrice(out check,out price);       //Eger price deyeri reqem daxil edilmeyibse yeniden isteyen metod
            product.Price=price;
            

            int count=0;
            AddProductCount(out check,out count);      // Eger count deyeri reqem daxil edilmeyibse yeniden isteyen metod
            product.Count = count;


        }

        static void ShowInfo()
        {
            if (Market.Products.Length==0)
            {
                Console.WriteLine("Markete erzaq elave olunmayib !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            for (int i = 0; i < Market.Products.Length; i++)
            {
                Product item = Market.Products[i];
                Console.WriteLine($"Adi-{item.Name} Qiymeti-{item.Price} AZN  Sayi-{item.Count} eded   Nomresi-{item.No}");
            }
        }

        static void SellWithProductNo()
        {
            if (Market.Products.Length>0)
            {
                Console.WriteLine("Mehsulun nomresini daxil edin");
                string no = Console.ReadLine();
                Market.SellProduct(no);
            }
            else
            {
                Console.WriteLine("Evvelce bir mehsul elave edin !!!!!!!!!!!!!!!!!!!!!!!!!");
            }

        }

        static bool IsConvertToInt(string numStr,out int convertDigit)
        {
            bool check;

            check = int.TryParse(numStr, out convertDigit);
            if (check == false)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Reqem daxil edilmeyib !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            return check;
        }

        static void AddProductPrice(out bool check ,out int price)
        {
            do
            {
                Console.WriteLine("Product qiymetini daxil edin");
                string priceStr = Console.ReadLine();
                check = IsConvertToInt(priceStr, out price);               // Convert oluna bilmirse yeniden daxil etsin
            } while (check == false);
        }
        static void AddProductCount(out bool check,out int  count)
        {
            do
            {
                Console.WriteLine("Product sayini daxil edin");
                string countStr = Console.ReadLine();
                check = IsConvertToInt(countStr, out count);
            } while (check == false);
        }
    }
}
