using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    interface IRepository
    {
        void GetAllProducts(string x);
        void SaveItemById(string x,int id);
        int BookItemById(string x,int id);
        int GetAllBookedProducts();

    }
}
