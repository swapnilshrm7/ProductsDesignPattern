using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolid
{
    interface ILogging
    {
        void Log(string MessageToBeLogged,string FileAddress);
    }
}
