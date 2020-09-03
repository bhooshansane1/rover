using RoverApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp.Models
{
    public class Rover : IRover
    {
        
        private Direction _direction;
        private Point _position;

        public Rover(Point position, Direction direction)
        {
            _position = position;
            _direction = direction;
        }
        public Point GetPosition()
        {
            return _position;
        }
        public void SetPosition(Point position)
        {
            _position = position;
        }
        public Direction GetDirection()
        {
            return _direction;
        }
        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }
        public string GetCurrentPosition()
        {
            return _position.X.ToString() + " " + _position.Y.ToString() + " " + _direction.ToString();
        }
        public bool IsValidPosition(PlateuArea plateuArea)
        {
            double upperX = plateuArea.GetUpperRightPoint().X;
            double upperY = plateuArea.GetUpperRightPoint().Y;
            double lowerX = plateuArea.GetBottomLeftPoint().X;
            double lowerY = plateuArea.GetBottomLeftPoint().Y;

            if (_position.X > upperX || _position.X< lowerX || _position.Y> upperY || _position.Y < lowerY)
            {
                return false;
            }

            return true;
        }
        public bool TryNavigate(string navigation, PlateuArea plateuArea)
        {
            for (int i = 0; i < navigation.Length; i++)
            {
                Navigate(navigation[i]);
            }
            return IsValidPosition(plateuArea);
        }

        private void Navigate(char key)
        {
            switch (key)
            {
                case 'R':
                    TurnRight(_direction);
                    break;
                case 'L':
                    TurnLeft(_direction);
                    break;
                case 'M':
                    Move();
                    break;
                default:
                    break;
            }
        }
        private void TurnRight(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    _direction = Direction.E;
                    break;
                default:
                    _direction--;
                    break;
            }
        }
        private void TurnLeft(Direction direction)
        {
            switch (direction)
            {
                case Direction.E:
                    _direction = Direction.N;
                    break;
                default:
                    _direction++;
                    break;
            }
        }
        private void Move()
        {
            switch (_direction)
            {
                case Direction.N:
                    _position.Y += 1;
                    break;
                case Direction.W:
                    _position.X -= 1;
                    break;
                case Direction.S:
                    _position.Y -= 1;
                    break;
                case Direction.E:
                    _position.X += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
