using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoverApp.Contracts;

namespace RoverApp.Models
{
    public class PlateuArea: IPlateuArea
    {
        private Point _upperRight;
        private Point _bottomLeft;


        public PlateuArea(Point upperRight, Point bottomLeft)
        {
            _upperRight = upperRight;
            _bottomLeft = bottomLeft;
        }

        public void SetPoints(Point upperRight)
        {
            _upperRight = upperRight;
            _bottomLeft = new Point();
        }
        public Point GetUpperRightPoint()
        {
            return _upperRight;
        }
        public Point GetBottomLeftPoint()
        {
            return _bottomLeft;
        }
    }
}
