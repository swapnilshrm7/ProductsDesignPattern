using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    class Program
    {
        static void Main(string[] args)
        {
            int TotalPrice = 0;
            int profit = 0;
            try
            {
                string desc="";
                string YorN = "";
                while (desc != "exit")
                {
                    Console.WriteLine("Enter the product you want : \n\n air \n hotel \n activity \n car \n exit: ");
                    desc = Console.ReadLine();
                    Logging.Instance.Log("Getting input from user", "C:\\LogFile.txt");
                    string TypeOfProduct;
                    ProfitBasedOnType getprofit = new ProfitBasedOnType();
                    Initializer product = new Initializer();
                    IProduct prod = product.GetProduct(desc);
                    Logging.Instance.Log("Getting type of product", "C:\\LogFile.txt");
                    TypeOfProduct = prod.GetTypeOfProduct();
                    Console.WriteLine(TypeOfProduct);
                    Repository repo = new Repository();
                    repo.GetAllProducts(TypeOfProduct);
                    Console.WriteLine("Enter the product id you are interested in :");
                    int InterestedId= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Book the product or save it for later ?");
                    string BookOrSave = Console.ReadLine();
                    if (BookOrSave == "book")
                    {
                        Logging.Instance.Log("Calling book method", "C:\\LogFile.txt");
                        profit = getprofit.GetProfitAmount(TypeOfProduct);
                        TotalPrice += profit+repo.BookItemById(TypeOfProduct, InterestedId);
                        prod.Book();
                    }
                    else if (BookOrSave == "save")
                    {
                        Logging.Instance.Log("Calling Save method", "C:\\LogFile.txt");
                        Console.WriteLine("save in file or database :");
                        string input = Console.ReadLine();
                        if(input=="database")
                        repo.SaveItemById(TypeOfProduct, InterestedId);
                        else if(input=="file")
                        prod.Save();
                    }
                    Console.WriteLine("Do you want the Total Price ? Y/N :");
                    YorN= Console.ReadLine();
                    if(YorN=="Y")
                    {
                        Logging.Instance.Log("Getting all booked products", "C:\\LogFile.txt");
                        TotalPrice = repo.GetAllBookedProducts();
                        Console.WriteLine("Total Amount payable : {0}",TotalPrice);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
