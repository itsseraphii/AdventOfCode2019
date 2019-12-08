using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoCDay6
{
    class Day6
    {
        static void Main(string[] args)
        {
            string pathToFile = @"C:\Users\Eclipse\Documents\GitHub\AdventOfCode2019\input\day6.txt";
            string[] data = ReadFile(pathToFile, '\r');

            CB COM = new CB("COM");

            CreateMap(COM, data);

            Console.WriteLine("COM Orbits : " + COM.Orbits);

            CB YOU = COM.FindCB("YOU");
            CB SAN = COM.FindCB("SAN");


            Console.WriteLine("Minimal Transfers : " + MinimalTransfers(YOU, SAN));
            Console.ReadKey();

        }

        static void CreateMap(CB CenterOfMass, string[] input)
        {
            foreach (string s in input)
            {
                string[] val = s.Split(')');
                if(val[0] == CenterOfMass.Name)
                {
                    CreateMap(CenterOfMass.AddChild(new CB(val[1])), input);
                }
            }
            
        }

        static int MinimalTransfers(CB Source, CB Destination)
        {
            List<CB> SourceParents = Source.Parents();
            List<CB> DestinationParents = Destination.Parents();

            int counter1 = 0;
            int counter2;

            foreach (CB stellar1 in SourceParents)
            {
                counter2 = 0;
                foreach (CB stellar2 in DestinationParents)
                {
                    if (stellar1 == stellar2)
                    {
                        return counter1 + counter2 - 2;
                    }
                    counter2++;
                }
                counter1++;
            }

            return -1;
        }


        public static string[] ReadFile(string path, char seperator)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(seperator);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('\n', ' ').Replace('\r', ' ').Trim();

            }

            return lines;
        }
    }
}
