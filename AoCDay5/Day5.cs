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
        const int JUMP_IF_TRUE = 5;
        const int JUMP_IF_FALSE = 6;
        const int LESS_THAN = 7;
        const int EQUALS = 8;

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
                int startInsValue = instruction;

                //Set Values of params
                if (iInst[2] == PARAM_IMMI)
                    iParam1 = iData[instruction + 1];
                else
                    iParam1 = iData[iData[instruction + 1]];


                switch (opCode)
                {
                    case ADD:
                        numParams = 3;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        iData[paraWrite] = iParam1 + iParam2;
                        break;
                    case MULTIPLY:
                        numParams = 3;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        iData[paraWrite] = iParam1 * iParam2;

                        break;
                    case STORE:
                        numParams = 1;
                        paraWrite = iData[instruction + 1];

                        Console.WriteLine("Enter value to store : ");
                        int val = int.Parse(Console.ReadLine());
                        iData[paraWrite] = val;
                        break;

                    case OUTPUT:
                        numParams = 1;
                        Console.WriteLine("Output = " + iParam1);
                        break;

                    case JUMP_IF_TRUE:
                        numParams = 2;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        if (iParam1 != 0)
                            instruction = iParam2;
                        break;

                    case JUMP_IF_FALSE:
                        numParams = 2;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        if (iParam1 == 0)
                            instruction = iParam2;
                        break;

                    case LESS_THAN:
                        numParams = 3;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        if (iParam1 < iParam2)
                            iData[paraWrite] = 1;
                        else
                            iData[paraWrite] = 0;
                        break;
                    case EQUALS:
                        numParams = 3;

                        if (iInst[3] == PARAM_IMMI)
                            iParam2 = iData[instruction + 2];
                        else
                            iParam2 = iData[iData[instruction + 2]];

                        paraWrite = iData[instruction + 3];

                        if (iParam1 == iParam2)
                            iData[paraWrite] = 1;
                        else
                            iData[paraWrite] = 0;
                        break;
                }

                if(startInsValue == instruction)
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
