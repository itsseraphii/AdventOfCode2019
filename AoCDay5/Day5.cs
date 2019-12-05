using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoCDay5
{
    class Day5
    {
        const int EXIT_CODE = 99;
        const int ADD = 1;
        const int MULTIPLY = 2;
        const int STORE = 3;
        const int OUTPUT = 4;
        const int PARAM_POS = 0;
        const int PARAM_IMMI = 1;

        static void Main(string[] args)
        {
            string path = @"C:\Users\Jordan\Documents\AdventOfCode2019\input\day5.txt";
            string[] data = ReadFile(path, ',');
            int[] iData = LoadData(data);

            int yahoo = RunComputerV2(iData);

            Console.WriteLine(yahoo);
            Console.ReadKey();
        }

        public static int RunComputerV2(int[] iData)
        {
            
            int instruction = 0;
            while (iData[instruction] != EXIT_CODE)
            {
                //Instruction interpreter
                int[] iInst = new int[5];
                char[] cInst = String.Format("{0}", iData[instruction]).ToCharArray();

                for (int i = 0; i < cInst.Length; i++)
                {
                    iInst[i] = int.Parse(cInst[cInst.Length - 1 - i].ToString());
                }
                //01101


                //EDCBA <- iInstFormat
                //DE = OPCODE
                //A = param3, B = param2, C = param1
                int opCode = int.Parse(string.Format("{0}{1}", iInst[1], iInst[0]));

                int numParams = 0, iParam1, iParam2, paraWrite;


                switch (opCode)
                {
                    case ADD:
                        numParams = 3;
                        //Set values of params
                        if (iInst[2] == 1)
                            iParam1 = iData[instruction + 1];
                        else
                            iParam1 = iData[iData[instruction + 1]];

                        if (iInst[3] == 1)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        iData[paraWrite] = iParam1 + iParam2;
                        break;
                    case MULTIPLY:
                        numParams = 3;
                        if (iInst[2] == 1)
                            iParam1 = iData[instruction + 1];
                        else
                            iParam1 = iData[iData[instruction + 1]];

                        if (iInst[3] == 1)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        iData[paraWrite] = iParam1 * iParam2;

                        break;
                    case STORE:
                        numParams = 1;
                        Console.WriteLine("Enter value to store : ");
                        int val = int.Parse(Console.ReadLine());

                        paraWrite = iData[instruction + 1];
                        iData[paraWrite] = val;
                        break;
                    case OUTPUT:
                        numParams = 1;
                        if (iInst[2] == 1)
                            iParam1 = iData[instruction + 1];
                        else
                            iParam1 = iData[iData[instruction + 1]];

                        Console.WriteLine("Output = " + iParam1);
                        break;
                }

                instruction += numParams + 1;
            }
            return iData[0];
        }

        public static int[] LoadData(string[] sData)
        {
            int[] iData = new int[sData.Length];

            for (int i = 0; i < sData.Length; i++)
            {
                iData[i] = int.Parse(sData[i]);
                if (iData[i] < 0)
                    Console.WriteLine("negative");
            }

            return iData;
        }

        public static string[] ReadFile(string path, char seperator)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(seperator);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace('\n', ' ').Replace('\r', ' ');
                lines[i].Trim();
            }

            return lines;
        }
    }
}
