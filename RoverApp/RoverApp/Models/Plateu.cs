using RoverApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Models
{
    public class Plateu:IPlateu
    {
        private PlateuArea _plateuArea;
        private readonly List<Rover> rovers = new List<Rover>();


        public Plateu(PlateuArea plateuArea)
        {
            _plateuArea = plateuArea;
        }


        public void SetArea(PlateuArea plateuArea)
        {
            _plateuArea = plateuArea;
        }
        public PlateuArea GetArea()
        {
            return _plateuArea;
        }
        public void AddRover(Rover rover)
        {
            rovers.Add(rover);
        }
        public List<Rover> GetAllRovers()
        {
            return rovers;
        }
    }
}
