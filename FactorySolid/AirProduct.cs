using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    class AirProduct : IProduct
    {
        List<AirList> FlightDetails = new List<AirList> { };
        public string GetTypeOfProduct()
        {
            Logging.Instance.Log("Returning product type air", "C:\\LogFile.txt");
            return "AirProducts";
        }
        public void Book()
        {
            Console.WriteLine("Booking air product");
            Logging.Instance.Log("air product booked", "C:\\LogFile.txt");
            Logging.Instance.Log("air product booked", "C:\\SaveFile.txt");
        }
        public void Save()
        {
            Console.WriteLine("Saving air Product");
            Logging.Instance.Log("air product saved", "C:\\LogFile.txt");
        }
    }
}
