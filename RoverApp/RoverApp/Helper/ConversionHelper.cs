using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Helper
{
    public class ConversionHelper
    {
        public static Point ToPoint(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] inputString = input.Split(' ');
                if (ValidationHelper.IsValidPointString(input))
                {
                    if (!ValidationHelper.IsVeryLargeValue(inputString[0]) && !ValidationHelper.IsVeryLargeValue(inputString[1]))
                        return new Point(ToDouble(inputString[0]), ToDouble(inputString[1]));
                }
            }
            return null;
        }

        public static double ToDouble(string str)
        {
            
            double.TryParse(str, out double temp);
            return temp;
        }

        public static Point DefaultPoint()
        {
            return new Point(0, 0);
        }

        public static string ExtractPointFromPosition(string position)
        {
            string[] positionArr = position.Split(' ');
            if (ValidationHelper.IsValidPositionString(position))
            {
                return string.Join(" ",positionArr,0, 2);
            }
            return null;
        }

        public static string ExtractDirectionFromPosition(string position)
        {
            string[] positionArr = position.Split(' ');
            if (ValidationHelper.IsValidPositionString(position))
            {
                return positionArr[2];
            }
            return null;
        }

        public static Direction ToDirection(string direction)
        {
            switch (direction)
            {
                case "N": return Direction.N;
                case "W": return Direction.W;
                case "S": return Direction.S;
                case "E": return Direction.E;
                default: return Direction.Unknown;
            }
        }
    }
}
