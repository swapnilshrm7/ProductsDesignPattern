using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    interface IProduct
    {
        string GetTypeOfProduct();
        void Save();
        void Book();
    }
}
