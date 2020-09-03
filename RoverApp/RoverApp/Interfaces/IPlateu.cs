using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Interfaces
{
    interface IPlateu
    {
        void SetArea(PlateuArea roverDimention);
        PlateuArea GetArea();
        void AddRover(Rover rover);
        List<Rover> GetAllRovers();
    }
}
