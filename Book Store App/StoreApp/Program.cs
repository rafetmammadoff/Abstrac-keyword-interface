using ClassLibrary;
using System;

namespace StoreApp
{
    internal class Program
    {
        static Market Bravo = new Market();
        static void Main(string[] args)
        {
            int input=0;
            bool parsable;
            do
            {
                Console.WriteLine("Proqrama xos geldiniz.");
                Console.WriteLine("ProductLimiti daxil edin");
                string inputStr = Console.ReadLine();
                parsable=IsConvertToInt(inputStr, input);
                
            } while (parsable==false);



            Bravo.ProductLimit = input;
            string select;
            do
            {
                Console.WriteLine("1-Product elave edin");
                Console.WriteLine("2-Mehsul satin");
                Console.WriteLine("3-Mehsullara baxin");
                Console.WriteLine("4-Proqramdan cixin");
                select = Console.ReadLine();

                SelectedProses(select);
                
            } while (select != "4");

            
        }

        static void SelectedProses(string no)
        {
            switch (no)
            {
                case "1":
                    Product product = new Product();
                    AddProductInfo(product);
                    Bravo.AddProduct(product);
                    break;
                case "2":
                    SellWithProductNo();
                    break;

                case "3":
                    ShowInfo();
                    break;

                default:
                    Console.WriteLine("Secim duzgun deyil");
                    break;
            }
        }

        static void AddProductInfo(Product newProduct)
        {
            
            Console.WriteLine("Product adini daxil edin");
            newProduct.Name = Console.ReadLine();

            Console.WriteLine("Product nomresini daxil edin");
            newProduct.No = Console.ReadLine();

            bool check;
            int price=0;
            do
            {
                Console.WriteLine("Product qiymetini daxil edin");
                string priceStr = Console.ReadLine();
                check=IsConvertToInt(priceStr,price);
            } while (check==false);

            newProduct.Price=price;

            Console.WriteLine("Product sayini daxil edin");
            newProduct.Count = Convert.ToInt32(Console.ReadLine());


        }

        static void ShowInfo()
        {
            for (int i = 0; i < Bravo.Products.Length; i++)
            {
                Product item = Bravo.Products[i];
                Console.WriteLine($"Adi-{item.Name} Qiymeti-{item.Price} Sayi-{item.Count} Nomresi-{item.No}");
            }
        }

        static void SellWithProductNo()
        {
            if (Bravo.Products.Length>0)
            {
                Console.WriteLine("Mehsulun nomresini daxil edin");
                string no = Console.ReadLine();
                Bravo.SellProduct(no);
            }
            else
            {
                Console.WriteLine("Evvelce bir mehsul elave edin !!!");
            }

        }

        static bool IsConvertToInt(string numStr,int convertDigit)
        {
            bool check;

            check = int.TryParse(numStr, out convertDigit);
            if (check == false)
            {
                Console.WriteLine("Reqem daxil edin");
            }
            return check;
        }
    }
}
