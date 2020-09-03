using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoverApp.Models;

namespace RoverApp.Contracts
{
    public interface IPlateuArea
    {
        void SetPoints(Point upperRight);
    }
}
