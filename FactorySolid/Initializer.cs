using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    class Initializer
    {
        public IProduct GetProduct(string desc)
        {
            Logging.Instance.Log("Inside get product description function", "C:\\LogFile.txt");
            switch (desc)
            {
                case "car":
                    return new CarProduct();
                case "air":
                    return new AirProduct();
                case "activity":
                    return new ActivityProduct();
                case "hotel":
                    return new HotelProduct();
                default:
                    throw new Exception();
            }

        }
    }
}
