using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay3
{
    class Path
    {
        private Coords startCoord;
        private Coords destinationCoord;
        private char direction;
        private int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public char Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Coords DestinationCoord
        {
            get { return destinationCoord; }
            set { destinationCoord = value; }
        }


        public Coords StartCoord
        {
            get { return startCoord; }
            set { startCoord = value; }
        }

        public Path()
        {
            startCoord = new Coords();
            destinationCoord = new Coords();
            direction = 'U';
            distance = 0;
        }

        public Path(Path copiedPath)
        {
            startCoord = new Coords(copiedPath.startCoord);
            destinationCoord = new Coords(copiedPath.destinationCoord);
            direction = copiedPath.Direction;
            distance = copiedPath.distance;
        }

        public static bool operator !=(Path path1, Path path2)
        {
            return !(path1 == path2);
        }

        public static bool operator ==(Path path1, Path path2)
        {
            return path1.StartCoord == path2.StartCoord && path1.DestinationCoord == path2.DestinationCoord && path1.Direction == path2.Direction && path1.Distance == path2.Distance;
        }

        public Coords GetIntersection(Path otherPath)
        {
            Coords coords = new Coords();

            switch (this.Direction)
            {
                case 'R':
                    if (otherPath.Direction == 'D')
                    {
                        if (otherPath.DestinationCoord.X >= this.StartCoord.X && otherPath.DestinationCoord.X <= this.DestinationCoord.X
                            && this.StartCoord.Y >= otherPath.DestinationCoord.Y && this.StartCoord.Y <= otherPath.StartCoord.Y)
                            coords = new Coords(otherPath.DestinationCoord.X, this.StartCoord.Y);
                    }
                    else if(otherPath.Direction == 'U')
                    {
                        if (otherPath.DestinationCoord.X >= this.StartCoord.X && otherPath.DestinationCoord.X <= this.DestinationCoord.X
                            && this.StartCoord.Y <= otherPath.DestinationCoord.Y && this.StartCoord.Y >= otherPath.StartCoord.Y)
                            coords = new Coords(otherPath.DestinationCoord.X, this.StartCoord.Y);
                    }
                    break;
                case 'L':
                    if (otherPath.Direction == 'D')
                    {
                        if (otherPath.DestinationCoord.X <= this.StartCoord.X && otherPath.DestinationCoord.X >= this.DestinationCoord.X
                            && this.StartCoord.Y >= otherPath.DestinationCoord.Y && this.StartCoord.Y <= otherPath.StartCoord.Y)
                            coords = new Coords(otherPath.DestinationCoord.X, this.StartCoord.Y);
                    }
                    else if (otherPath.Direction == 'U')
                    {
                        if (otherPath.DestinationCoord.X <= this.StartCoord.X && otherPath.DestinationCoord.X >= this.DestinationCoord.X
                            && this.StartCoord.Y <= otherPath.DestinationCoord.Y && this.StartCoord.Y >= otherPath.StartCoord.Y)
                            coords = new Coords(otherPath.DestinationCoord.X, this.StartCoord.Y);
                    }
                    break;
            }

            return coords;
        }

    }
}
