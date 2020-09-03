using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Helper
{
    public class InputOutputHelper
    {
        public static string GetTrimUpperCase(string input)
        {
            return input.Trim().ToUpper();
        }
    }
}
