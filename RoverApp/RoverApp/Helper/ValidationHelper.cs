using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Helper
{
    public class ValidationHelper
    {
        private const string VALID_NAVIGATION = "RLM";
        public static bool IsValidPointString(string input)
        {
            string[] inputString = input.Split(' ');

            if (inputString.Length != 2)
                return false;
            foreach (string str in inputString)
            {
                if (!TryToDouble(str))
                    return false;
            }
            return true;
        }

        public static bool IsValidPositionString(string input)
        {
            string[] inputString = input.Split(' ');
            if (inputString.Length != 3)
                return false;
            else if (!TryToDouble(inputString[0]))
                return false;
            else if (!TryToDouble(inputString[1]))
                return false;
            return true;
        }

        public static bool TryToDouble(string str)
        {
            return double.TryParse(str, out double _);
        }

        public static bool IsValidNavigationString(string str)
        {
            foreach (char ch in str)
            {
                if (!VALID_NAVIGATION.Contains(ch))
                    return false;
            }
            return true;
        }

        public static bool IsVeryLargeValue(string str)
        {
            double.TryParse(str, out double temp);
            if (temp == double.MaxValue)
                return true;
            return false;
        }

        public static bool IsValidAreaString(string str)
        {
            string[] inputString = str.Split(' ');
            if (inputString.Length != 2)
                return false;
            foreach (char chr in inputString[0])
            {
                if (!char.IsDigit(chr))
                    return false;
            }

            foreach (char chr in inputString[1])
            {
                if (!char.IsDigit(chr))
                    return false;
            }
            return true;
        }
    }
}
