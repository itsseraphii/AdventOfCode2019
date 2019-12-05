using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay4
{
    class Day4
    {
        static void Main(string[] args)
        {
            int rMin = 246540, rMax = 787419, p1Valid = 0;

            for (int i = rMin; i < rMax; i++)
            {
                if (CheckValid(i.ToString()))
                    p1Valid++;

            }

            Console.WriteLine(p1Valid);
            Console.ReadKey();

        }

        public static bool CheckValid(string number)
        {
            char[] var = number.ToCharArray();
            bool hasDouble = false, decrease = false;

            for (int i = 0; i < var.Length-1; i++)
            {
                if (var[i] > var[i + 1])
                    decrease = true;
                //Part 1
                //if (var[i] == var[i + 1])
                //    hasDouble = true;
                    
                //Part 2
                if(i == 0) 
                {
                    if (var[i] == var[i + 1] && var[i] != var[i + 2])
                        hasDouble = true;

                }
                else if(i < 4)
                {
                    if (var[i] != var[i - 1] && var[i] == var[i + 1] && var[i] != var[i + 2])
                        hasDouble = true;
                }
                else if (i == 4)
                {
                    if (var[i] != var[i - 1] && var[i] == var[i + 1])
                        hasDouble = true;
                }

            }

            return (!decrease && hasDouble);
        }
    }
}
