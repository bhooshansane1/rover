using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoverApp.Models;

namespace RoverApp.Contracts
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
    }
}
