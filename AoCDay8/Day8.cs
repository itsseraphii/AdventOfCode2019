using System;
using System.IO;

namespace AoCDay8
{
    class Day8
    {
        const int pxWide = 25;
        const int pxTall = 6;
        const int TRANSPARENT = 2;
        const int WHITE = 1;
        const int BLACK = 0;

        static void Main(string[] args)
        {
            string pathToFile = @"C:\Users\Eclipse\Documents\GitHub\AdventOfCode2019\input\day8.txt";
            string data = ReadFile(pathToFile);

            int nbLayers = data.Length / (pxTall * pxWide);

            int layerLess0 = 0;
            int nb0 = int.MaxValue, nb1 = 0, nb2 = 0;
            int[,] finalImage = new int[pxWide, pxTall];

            for (int y = 0; y < pxTall; y++)
            {
                for (int x = 0; x < pxWide; x++)
                {
                    finalImage[x, y] = TRANSPARENT;
                }
            }

            for (int i = 0; i < nbLayers; i++)
            {
                int nb1Digits = 0, nb2Digits = 0, nb0Digits = 0;

                for (int y = 0; y < pxTall; y++)
                {
                    for (int x = 0; x < pxWide; x++)
                    {
                        char pixel = data[(i * pxTall * pxWide) + (y * pxWide) + x];

                        switch (pixel)
                        {
                            case '0':
                                nb0Digits++;
                                break;
                            case '1':
                                nb1Digits++;
                                break;
                            case '2':
                                nb2Digits++;
                                break;
                        }

                        if(finalImage[x,y] == TRANSPARENT)
                        {
                            finalImage[x, y] = (int)Char.GetNumericValue(pixel);
                        }
                    }
                }

                if(nb0Digits < nb0)
                {
                    nb0 = nb0Digits;
                    nb1 = nb1Digits;
                    nb2 = nb2Digits;
                    layerLess0 = i;
                }
            }


            Console.WriteLine("Day 8 Part 1");
            Console.WriteLine("Layer with least amout of 0 : Layer {0} with {1} zeros", layerLess0, nb0);
            Console.WriteLine("Amount of 1 : {0}\nAmount of 2 : {1}", nb1, nb2);
            Console.WriteLine("Part 1 answer : " + (nb1 * nb2));
            Console.WriteLine("\n\nFinal Message :\n");
            for (int y = 0; y < pxTall; y++)
            {
                for (int x = 0; x < pxWide; x++)
                {
                    char pixel;
                    switch (finalImage[x,y])
                    {
                        case WHITE:
                            pixel = 'W';
                            break;
                        default: //Transparent
                            pixel = ' ';
                            break;
                    }
                    Console.Write(pixel);
                }
                Console.WriteLine();
            }

            Console.ReadKey();


        }

        public static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            return file;
        }
    }
}
