using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCodeDay2
{
    class Day2
    {
        public const int EXIT_CODE = 99;
        public const int ADD = 1;
        public const int MULTIPLY = 2;


        static void Main(string[] args)
        {
            string path = @"C:\Users\Jordan\Documents\AdventOfCode2019\input\day2.txt";
            string[] data = ReadFile(path, ',');
            int[] iData = LoadData(data);

            Console.WriteLine("--- Day 2: 1202 Program Alarm ---");
            Console.WriteLine("Part 1");
            for (int i = 0; i < data.Length; i++)
            {
                iData[i] = int.Parse(data[i]);
            }

            //Before program.
            iData[1] = 12;
            iData[2] = 2;

            Console.WriteLine("Output value = {0}", RunComputer(iData));

            Console.ReadKey();

            Console.WriteLine("Part 2");
            int output = 0, noun = 0, verb = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    output = 0;
                    int[] p2Data = LoadData(data);

                    p2Data[1] = i;
                    p2Data[2] = j;

                    if (RunComputer(p2Data) == 19690720)
                    {
                        noun = i;
                        verb = j;
                        break;
                    }
                    if (noun != 0)
                        break;
                }
            }
            Console.WriteLine("Noun is {0}\nVerb is {1}", noun, verb);
            Console.WriteLine("Day 2 Part 2 answer = {0}", 100 * noun + verb);

            Console.ReadKey();

        }

        public static int RunComputer(int[] iData)
        {
            int instruction = 0;
            while(iData[instruction] != EXIT_CODE)
            {
                switch (iData[instruction])
                {
                    case ADD:
                        //Addition
                        int result = iData[iData[instruction + 1]] + iData[iData[instruction + 2]];
                        iData[iData[instruction + 3]] = result;
                        break;
                    case MULTIPLY:
                        int resultMul = iData[iData[instruction + 1]] * iData[iData[instruction + 2]];
                        iData[iData[instruction + 3]] = resultMul;
                        break;
                }

                instruction += 4;
            }
            return iData[0];
        }

        public static int[] LoadData(string[] sData)
        {
            int[] iData = new int[sData.Length];

            for (int i = 0; i < sData.Length; i++)
            {
                iData[i] = int.Parse(sData[i]);
            }

            return iData;
        }

        public static string[] ReadFile(string path, char seperator)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(seperator);

            return lines;
        }
    }
}
