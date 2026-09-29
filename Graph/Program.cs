using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("graph.txt");
            char[] letters = lines[0].Replace(" ", "").ToCharArray();
            var graph = new Dictionary<char, List<char>>();
            foreach (var c in letters)
            {
                graph[c] = new List<char>();
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] row = lines[i].Split(' ');
                var from = row[0][0];
                for (int j = 1; j < row.Length; j++)
                {
                    if (row[j] == "1")
                    {
                        graph[from].Add(letters[j - 1]);
                    }
                }
            }

            foreach (var c in graph)
            {
                Console.Write($"{c.Key}: ");
                foreach (var s in c.Value)
                {
                    Console.Write($"{s} ");
                }
                Console.WriteLine();
            }
        }
    }
}
