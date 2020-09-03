using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Helper
{
    public class MessageHelper
    {
        public static void ErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
