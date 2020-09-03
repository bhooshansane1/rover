using RoverApp.Helper;
using RoverApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoverApp
{
    public class Execution
    {
        public static Plateu GetPlateuData()
        {
            ConsoleKeyInfo key;
            PlateuArea plateuArea = GetPlateuArea();
            Plateu plateu = new Plateu(plateuArea);

            do
            {
                Rover rover = GetRover();
                if (rover.IsValidPosition(plateuArea) && TryNavigate(ref rover, plateuArea))
                {
                    plateu.AddRover(rover);
                }
                else
                {
                    MessageHelper.ErrorMessage("Position is out of Plateu !!!");
                }
                Console.WriteLine("Do you want to start new rover?Y/N");
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.N);
            return plateu;
        }

        public static void PrintResult(Plateu plateu)
        {
            Console.WriteLine("Result: ");
            foreach (Rover rvr in plateu.GetAllRovers())
            {
                Console.WriteLine(rvr.GetCurrentPosition());
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static Rover GetRover()
        {
            Rover rover;
            StringBuilder position = new StringBuilder();
            do
            {
                position.Clear();
                Console.WriteLine("Enter rover position:");
                position.Append(InputOutputHelper.GetTrimUpperCase(Console.ReadLine()));
                rover = new Rover(GetRoverPosition(position.ToString()), GetRoverDirection(position.ToString()));

            } while (rover.GetPosition() == null || rover.GetDirection() == Direction.Unknown);

            return rover;
        }

        private static Point GetRoverPosition(string position)
        {
            Point point = ConversionHelper.ToPoint(ConversionHelper.ExtractPointFromPosition(position));
            if (point == null)
                MessageHelper.ErrorMessage("Enter valid position !!!");
            return point;
        }

        private static Direction GetRoverDirection(string position)
        {
            Direction direction = ConversionHelper.ToDirection(ConversionHelper.ExtractDirectionFromPosition(position));
            if (direction == Direction.Unknown)
                MessageHelper.ErrorMessage("Enter valid direction !!!");
            return direction;
        }

        private static PlateuArea GetPlateuArea()
        {
            PlateuArea plateuArea;
            StringBuilder area = new StringBuilder();
            do
            {
                area.Clear();
                Console.WriteLine("Enter plateu area:");
                area.Append(InputOutputHelper.GetTrimUpperCase(Console.ReadLine()));

                Point upperRightPoint = ConversionHelper.ToPoint(area.ToString());
                Point lowerLeftPoint = ConversionHelper.DefaultPoint();
                plateuArea = new PlateuArea(upperRightPoint, lowerLeftPoint);
                if (plateuArea.GetUpperRightPoint() == null)
                {
                    MessageHelper.ErrorMessage("Enter valid area !!!");
                }
            } while (plateuArea.GetUpperRightPoint() == null);
            return plateuArea;
        }

        private static bool TryNavigate(ref Rover rover, PlateuArea plateuArea)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            StringBuilder navigation = new StringBuilder();
            bool isValid;
            do
            {
                navigation.Clear();
                Console.WriteLine("Enter navigation:");
                navigation.Append(InputOutputHelper.GetTrimUpperCase(Console.ReadLine()));
                isValid = ValidationHelper.IsValidNavigationString(navigation.ToString());
                if (!isValid)
                    MessageHelper.ErrorMessage("Enter valid navigation !!!");
                else
                {
                    if (rover.TryNavigate(navigation.ToString(), plateuArea))
                    {
                        Console.WriteLine("Stop rover? Y/N");
                        key = Console.ReadKey();
                        Console.WriteLine();
                    }
                    else
                    {
                        MessageHelper.ErrorMessage("Position is out of Plateu !!!");
                    }
                }
            } while (!isValid || key.Key != ConsoleKey.Y);
            return true;
        }
    }
}
