using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    class CarProduct : IProduct
    {
        List<CarList> CarDetails = new List<CarList> { };
        public string GetTypeOfProduct()
        {
            Logging.Instance.Log("Returning product type car", "C:\\LogFile.txt");
            return "CarProducts";
        }
        public void Book()
        {
            Console.WriteLine("Booking car product");
            Logging.Instance.Log("car product booked", "C:\\LogFile.txt");
            Logging.Instance.Log("car product booked", "C:\\SaveFile.txt");
        }
        public void Save()
        {
            Console.WriteLine("Saving car Product");
            Logging.Instance.Log("car product saved", "C:\\LogFile.txt");
        }
    }
}
