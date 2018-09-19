using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FactorySolid
{
    public class Logging
    {
        private static Logging obj;
        private Logging() { }
        public static Logging Instance
        {
            get
            {
                if (obj == null)
                    obj = new Logging();
                return obj;
            }
        }
        public void Log(string Message, string address)
        {
            File.AppendAllText(address, Message);
            File.AppendAllText(address, Environment.NewLine);
        }
    }
}
