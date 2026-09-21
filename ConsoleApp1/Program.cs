using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("test.txt");
            int height = lines.Length;
            int weight = lines[0].Length;
            int y = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            char[,] charArray = new char[height, weight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    charArray[i, j] = lines[i][j];
                }
            }
            char start = charArray[y, x];
            if (start != '*')
                Replacing(charArray, y, x, start);

            Print(charArray);
        }
        static void Print(char[,] charArray)
        {
            int rows = charArray.GetLength(0);
            int cols = charArray.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(charArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Replacing(char[,] charArray, int y, int x, char target)
        {
            int height = charArray.GetLength(0);
            int weight = charArray.GetLength(1);
            if (y < 0 || x < 0 || y >= height || x >= weight) return;
            if (charArray[y, x] != target) return;
            char startPoint = charArray[y, x];
            charArray[y, x] = '*';
            Replacing(charArray, y - 1, x, target);
            Replacing(charArray, y + 1, x, target);
            Replacing(charArray, y, x - 1, target);
            Replacing(charArray, y, x + 1, target);
        }

    }
}
