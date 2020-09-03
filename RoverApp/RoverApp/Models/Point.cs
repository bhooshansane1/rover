using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoverApp.Contracts;

namespace RoverApp.Models
{
    public class Point : IPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double xAxis=0, double yAxis=0)
        {
            X = xAxis;
            Y = yAxis;
        }

    }
}
