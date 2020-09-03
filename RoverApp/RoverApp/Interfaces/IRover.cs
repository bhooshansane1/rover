using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Contracts
{
    public interface IRover
    {
        void SetPosition(Point position);
        Point GetPosition();
        Direction GetDirection();
        void SetDirection(Direction direction);
        string GetCurrentPosition();
        bool TryNavigate(string navigation, PlateuArea plateuArea);
        bool IsValidPosition(PlateuArea plateuArea);
    }
}
