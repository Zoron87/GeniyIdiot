using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiot.Common
{
    public static class Logs
    {
        public static void OuputToConsole(string message = "")
        {
            Console.WriteLine(message);
        }
        public static string InputFromConsole()
        {
            return Console.ReadLine();
        }
    }
}
