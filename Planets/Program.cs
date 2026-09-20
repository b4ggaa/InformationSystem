using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Planets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = new List<Planet>();
            while (true)
            {
                Console.WriteLine("Меню выбора:");
                Console.WriteLine("1 - добавить планеты");
                Console.WriteLine("2 - удалить планеты");
                Console.WriteLine("3 - список планет");
                Console.WriteLine("0 - выход");
                string choice = Console.ReadLine();

                if (choice == "0") 
                {
                    break;
                }

                if (choice == "1")
                {
                    Console.WriteLine("Введите название планеты в кавычках, год в формате гггг.мм.дд и радиус планеты через пробел");
                    string input = Console.ReadLine();
                    planets.Add(Parsing(input));
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Введите название планеты которую надо удалить:");
                    string name = Console.ReadLine();
                    foreach (Planet planet in planets)
                    {
                        if (planet.Name == name) 
                        {
                            planets.RemoveAt(planet);
                            break;
                        }
                    }
                }
                else if (choice == "3")
                {
                    foreach (Planet planet in planets)
                    {
                        Console.WriteLine(planet.Name);
                    }
                }
                else 
                {
                    Console.WriteLine("Неизвестная команда");
                }
            }
        }
        static Planet Parsing(string input) 
        {
            int first = input.IndexOf('"');
            int second = input.IndexOf('"', first + 1);
            string name = input.Substring(first + 1, second - first - 1);

            string rest = input.Substring(second + 1).Trim();
            string[] parts = rest.Split(' ');

            Planet planet = new Planet();
            planet.Name = name;
            planet.Date = DateTime.Parse(parts[0]);
            planet.Radius = double.Parse(parts[1]);

            Console.WriteLine($"Планета: {planet.Name} Дата открытия: {planet.Date:yyyy.MM.dd},Радиус: {planet.Radius}");

            return planet;
        }
    }
}
