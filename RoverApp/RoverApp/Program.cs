using RoverApp.Helper;
using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RoverApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                Plateu plateu = Execution.GetPlateuData();

                Execution.PrintResult(plateu);
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.Message);
                throw;
            }
        }
    }
}
