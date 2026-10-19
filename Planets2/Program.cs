using Planets2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    PlanetManager manager;
    PlanetParser parser;
    FileLogger logger;
    TextReader input;
    List<MenuItem> menuItems;

    public Program(PlanetManager manager, PlanetParser parser, FileLogger logger, TextReader input)
    {
        this.manager = manager;
        this.parser = parser;
        this.logger = logger;

        if (input == null)
        {
            this.input = Console.In;
        }
        else
        {
            this.input = input;
        }
    }
    public static void Main(string[] args)
    {
        FileLogger logger = new FileLogger();
        PlanetManager manager = new PlanetManager();
        PlanetParser parser = new PlanetParser();
        Program program = new Program(manager, parser, logger, null);
        Menu mainMenu = new Menu();
        mainMenu.AddItem("Добавить планеты из файла", program.LoadPlanetsFromFile);
        mainMenu.AddItem("Удалить планету по названию", program.DeletePlanet);
        mainMenu.AddItem("Список всех планет", program.ShowAllPlanets);
        mainMenu.Run();
    }
    public void LoadPlanetsFromFile()
    {
        if (!File.Exists("Planets.txt"))
        {
            Console.WriteLine($"Файл Planets.txt не найден.");
            logger.LogError($"Файл Planets.txt не найден.");
            return;
        }

        string[] lines = File.ReadAllLines("Planets.txt");

        List<string> errors;
        List<Planet> planets = parser.ParseLines(lines, out errors, skipInvalid: true);

        manager.AddRange(planets);

        foreach (string err in errors)
        {
            logger.LogError(err);
        }

        Console.WriteLine($"Успешно загружено: {planets.Count}");

        if (errors.Count > 0)
        {
            Console.WriteLine($"Пропущено некорректных строк: {errors.Count}");
        }
    }

    public void DeletePlanet()
    {
        Console.Write("Введите название планеты для удаления: ");
        string name = input.ReadLine();

        if (manager.RemoveByName(name))
        {
            Console.WriteLine("Планета успешно удалена.");
        }
        else
        {
            Console.WriteLine("Планета с таким названием не найдена.");
        }
    }

    public void ShowAllPlanets()
    {
        IReadOnlyList<Planet> list = manager.GetAll();

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