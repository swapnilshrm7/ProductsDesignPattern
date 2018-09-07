using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid 
{
    class ActivityProduct : IProduct
    {
        List<ActicityList> ActivityProducts = new List<ActicityList> { };
        public string GetTypeOfProduct()
        {
            Logging.Instance.Log("Returning product type activity", "C:\\LogFile.txt");
            return "ActivityProducts";
        }
        public void Book()
        {
            Console.WriteLine("Booking activity product");
            Logging.Instance.Log("activity product booked", "C:\\LogFile.txt");
            Logging.Instance.Log("activity product booked", "C:\\SaveFile.txt"); 
        }
        public void Save()
        {
            Console.WriteLine("Saving activity Product");
            Logging.Instance.Log("activity Product saved", "C:\\LogFile.txt");
        }
    }
}
