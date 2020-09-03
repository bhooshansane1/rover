using System;
using RoverApp.Models;
using RoverApp.Helper;
using Xunit;

namespace RoverApp.Tests
{
    public class RoverFixtures
    {
        private Rover rover;
        private PlateuArea plateuArea;
        private Point upperRightPoint;
        private Point lowerLeftPoint;
        private Plateu plateu;
        private Direction direction;
        private Point position;



        private void SetRover(string plateuString,string positionString)
        {
            upperRightPoint = ConversionHelper.ToPoint(plateuString);
            lowerLeftPoint = ConversionHelper.DefaultPoint();
            plateuArea = new PlateuArea(upperRightPoint, lowerLeftPoint);
            plateu = new Plateu(plateuArea);
            string pos = positionString;
            position = ConversionHelper.ToPoint(ConversionHelper.ExtractPointFromPosition(pos));
            direction = ConversionHelper.ToDirection(ConversionHelper.ExtractDirectionFromPosition(pos));
            rover = new Rover(position, direction);
        }

        [Fact]
        public void Invalid_Plateu_Area_String_Test()
        {
            Assert.False(ValidationHelper.IsValidAreaString("afsg hsgsjk"));
        }

        [Fact]
        public void Invalid_Rover_Position_Characters_Test()
        {
            Assert.False(ValidationHelper.IsValidPositionString("adhasg asdkjhasjd asdasjkda"));
        }

        [Fact]
        public void Invalid_Navigation_Characters_Test()
        {
            Assert.False(ValidationHelper.IsValidNavigationString("akjhkasda kjasdkja jaskjdhajksdas"));
        }

        [Fact]
        public void Invalid_Rover_Position_Test()
        {
            upperRightPoint = ConversionHelper.ToPoint("100 100");
            lowerLeftPoint = ConversionHelper.DefaultPoint();
            plateuArea = new PlateuArea(upperRightPoint, lowerLeftPoint);
            plateu = new Plateu(plateuArea);
            string pos = "101 101 S";
            position = ConversionHelper.ToPoint(ConversionHelper.ExtractPointFromPosition(pos));
            direction = ConversionHelper.ToDirection(ConversionHelper.ExtractDirectionFromPosition(pos));
            rover = new Rover(position, direction);

            Assert.False(rover.IsValidPosition(plateuArea));
        }


        [Fact]
        public void Invalid_Rover_Direction_Test()
        {
            Assert.Equal(Direction.Unknown,ConversionHelper.ToDirection("D"));
        }

        [Fact]
        public void Invalid_Rover_Navigate_Test()
        {
            SetRover("5 5", "1 2 N");

            Assert.False(rover.TryNavigate("LMMMM", plateuArea));
        }

       

        [Fact]
        public void Very_Large_Numbers_Plot_Area_Test()
        {
            Assert.False(ValidationHelper.IsVeryLargeValue("9999999999999999999 99999999999999999999999"));
        }

        [Fact]
        public void Decimal_Numbers_Plot_Area_Test()
        {
            SetRover("50.9 50.8", "1.1 2.1 N");
            rover.TryNavigate("MMMMMMMMRMMMMMMMMMRMMM", plateuArea);

            Assert.Equal("10.1 7.1 S", rover.GetCurrentPosition());
        }

        [Fact]
        public void Get_Current_Position_Of_Rover_Test()
        {
            SetRover("5 5", "3 3 E");
            rover.TryNavigate("MMRMMRMRRM", plateuArea);

            Assert.Equal("5 1 E", rover.GetCurrentPosition());
        }
    }
}
