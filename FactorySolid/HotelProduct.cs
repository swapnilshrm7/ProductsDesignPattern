using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FactorySolid
{
    class HotelProduct : IProduct
    {
        List<HotelList> HotelDetails = new List<HotelList> { };
        string message;
        public string GetTypeOfProduct()
        {
            Logging.Instance.Log("Returning product type Hotel", "C:\\LogFile.txt");
            return "HotelProducts";
        }
        public void Book()
        {
            Console.WriteLine("Booking hotel product");
            Logging.Instance.Log("Hotel product booked","C:\\LogFile.txt");
            Logging.Instance.Log("Hotel product booked", "C:\\SaveFile.txt");
        }
        public void Save()
        {
            Console.WriteLine("Saving hotel Product");
            Logging.Instance.Log("Hotel Product saved","C:\\LogFile.txt");
        }
    }
}
