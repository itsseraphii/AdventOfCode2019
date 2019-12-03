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

            string[] wire1 = Day3ParseData(input[0]), wire2 = Day3ParseData(input[1]);



            Console.WriteLine(lol.First());
            lol = lol.Substring(1);
            Console.WriteLine(lol);
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
            return lines;
        }

    }
}
