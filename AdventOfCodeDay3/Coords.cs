using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay3
{
    class Coords
    {
        private int posX;
        private int posY;

        public int Y
        {
            get { return posY; }
            set { posY = value; }
        }


        public int X
        {
            get { return posX; }
            set { posX = value; }
        }

        public Coords()
        {
            posX = 0;
            posY = 0;
        }

        public Coords(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public Coords(Coords copiedCoords)
        {
            posX = copiedCoords.posX;
            posY = copiedCoords.posY;
        }

        public static bool operator ==(Coords cord1, Coords cord2)
        {
            return cord1.X == cord2.X && cord1.Y == cord2.Y;
        }

        public static bool operator !=(Coords cord1, Coords cord2)
        {
            return !(cord1 == cord2);
        }

        public override string ToString()
        {
            return String.Format("Position ( {0}, {1})", posX, posY);
        }

        public Path Movement(string instruction)
        {
            Coords destinationCoords = new Coords(this);

            Path path = new Path();
            path.StartCoord = new Coords(this);
            path.Direction = instruction.First();
            path.Distance = int.Parse(instruction.Substring(1));

            switch (path.Direction)
            {
                case 'L':
                    destinationCoords.X = this.X - path.Distance;
                    break;
                case 'R':
                    destinationCoords.X = this.X + path.Distance;
                    break;
                case 'U':
                    destinationCoords.Y = this.Y + path.Distance;
                    break;
                case 'D':
                    destinationCoords.Y = this.Y - path.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The direction that was entered is invalid.");
            }
            path.DestinationCoord = destinationCoords;

            this.X = destinationCoords.X;
            this.Y = destinationCoords.Y;

            return path;
        }
    }
}
