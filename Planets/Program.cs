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
        private static readonly PlanetManager Manager = new PlanetManager();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                if (choice == "0") break;

                ExecuteCommand(choice);
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n--- Меню выбора ---");
            Console.WriteLine("1 - Добавить планеты из файла");
            Console.WriteLine("2 - Удалить планету по названию");
            Console.WriteLine("3 - Список всех планет");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите команду: ");
        }

        private static void ExecuteCommand(string choice)
        {
            switch (choice)
            {
                case "1":
                    LoadPlanetsFromFile();
                    break;
                case "2":
                    DeletePlanet();
                    break;
                case "3":
                    ShowAllPlanets();
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }

        private static void LoadPlanetsFromFile()
        {
            Console.Write("Введите путь к файлу (например, planets.txt): ");
            string path = Console.ReadLine();
            try
            {
                var loaded = Parser.ParseFile(path);
                Manager.AddRange(loaded);
                Console.WriteLine($"Успешно загружено объектов: {loaded.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        private static void DeletePlanet()
        {
            Console.Write("Введите название планеты для удаления: ");
            string name = Console.ReadLine();
            if (Manager.RemoveByName(name))
            {
                Console.WriteLine("Планета успешно удалена.");
            }
            else
            {
                Console.WriteLine("Планета с таким названием не найдена.");
            }
        }

        private static void ShowAllPlanets()
        {
            var list = Manager.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("Список планет пуст.");
                return;
            }

            Console.WriteLine("\nСписок планет в системе:");
            foreach (Planet planet in list)
            {
                Console.WriteLine(planet.GetInfo());
            }
        }
    }
}
