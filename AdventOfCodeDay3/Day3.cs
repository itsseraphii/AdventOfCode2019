using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCodeDay3
{
    class Day3
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\Jordan\Documents\AdventOfCode2019\input\day3.txt";
            string[] input = ReadFile(path, '\n');

            string[] wire1Data = Day3ParseData(input[0]), wire2Data = Day3ParseData(input[1]);
            List<Path> wire1Path = new List<Path>(), wire2Path = new List<Path>();
            List<Coords> colisions = new List<Coords>();
            Coords wire1Coord = new Coords(), wire2Coord = new Coords(), centre = new Coords();

            for (int i = 0; i < wire1Data.Length; i++)
            {
                wire1Path.Add(wire1Coord.Movement(wire1Data[i]));
                wire2Path.Add(wire2Coord.Movement(wire2Data[i]));
            }


            List<Path[]> pathColisions = new List<Path[]>();
            foreach (Path object2 in wire2Path)
            {

                foreach (Path object1 in wire1Path)
                {
                    Coords colision = centre;
                    colision = object1.GetIntersection(object2);
                    if (colision != centre)
                    {
                        colisions.Add(colision);
                        Console.WriteLine("Colision! " + colision);

                        //storing the colision
                        Path[] pathCol = new Path[2];
                        pathCol[0] = object1;
                        pathCol[1] = object2;
                        pathColisions.Add(pathCol);
                    }
                }
            }

            Coords closest = new Coords();
            int closestDistance = 57005; //HEXA FTW
            foreach (Coords colision in colisions)
            {
                if(ManhattanDistance(centre, colision) <= closestDistance)
                {
                    closest = colision;
                    closestDistance = ManhattanDistance(centre, colision);
                }
            }

            Console.WriteLine("Manhattan closest distance = " + closestDistance);
            Console.WriteLine(closest);

            int smallestSteps = int.MaxValue;

            foreach (Path[] pathColision in pathColisions)
            {
                //Determine how many steps it took to get to that path
                int iWire1 = -1, iWire2 = -1, totSteps1 = 0, totSteps2 = 0;
                Path iWirePath1 = new Path(), iWirePath2 = new Path();
                wire1Coord = new Coords();
                wire2Coord = new Coords();
                do
                {
                    totSteps1 += Math.Abs(iWirePath1.Distance);
                    iWire1++;
                    iWirePath1 = wire1Coord.Movement(wire1Data[iWire1]);
                }
                while (iWirePath1 != pathColision[0]);

                do
                {
                    totSteps2 += Math.Abs(iWirePath2.Distance);
                    iWire2++;
                    iWirePath2 = wire2Coord.Movement(wire2Data[iWire2]);
                }
                while (iWirePath2 != pathColision[1]);

                if (smallestSteps >= totSteps1 + totSteps1)
                    smallestSteps = totSteps1 + totSteps2;
            }

            Console.WriteLine("The fewest combined steps are = " + smallestSteps + " steps.");

                Console.ReadKey();

        }

        public static string[] ReadFile(string path, char seperator)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(seperator);

            return lines;
        }

        public static string[] Day3ParseData(string strData)
        {
            string[] lines = strData.Split(',');
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains('\r'))
                    lines[i] = lines[i].Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            }

            return lines;
        }

        public static int ManhattanDistance(Coords coords1, Coords coords2)
        {
            return Math.Abs(coords1.X - coords2.X) + Math.Abs(coords1.Y - coords2.Y);
        }

    }
}
