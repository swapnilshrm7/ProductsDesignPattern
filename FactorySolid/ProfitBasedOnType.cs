using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid 
{
    class ProfitBasedOnType : ProfitAmount
    {
        public int GetProfitAmount(string Type)
        {
            Logging.Instance.Log("Inside Get profit amount function", "C:\\LogFile.txt");
            if (Type == "AirProducts")
                return 200;
            else if (Type == "ActivityProducts")
                return 80;
            else if (Type == "HotelProducts")
                return 300;
            else if (Type == "CarProducts")
                return 150;
            else
                return 0;
        }
    }
}
