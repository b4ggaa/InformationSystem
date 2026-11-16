using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Game
{
    public class Programm
    {
        static List<GameObject> heroes = new List<GameObject>();
        static void Main(string[] args)
        {
            Menu gameMenu = new Menu();
            gameMenu.AddItem("Считать персонажей из фалйа", LoadFromFile);
            gameMenu.AddItem("Вывести всех персонажей", ShowHeroes);
            gameMenu.Run();
        }
        static void LoadFromFile()
        {
            Console.WriteLine("Введите путь: ");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка файл не найден");
                return;
            }
            string[] lines = File.ReadAllLines(path);
            int count = 0;
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length < 4)
                {
                    continue;
                }
                ;
                string type = parts[0].ToLower();
                GameObject newObject = null;
                switch (type)
                {
                    case "мечник":
                        newObject = new Swordman();
                        break;
                    case "лучник":
                        newObject = new Archer();
                        break;
                    case "маг":
                        newObject = new Mag();
                        break;
                    default:
                        Console.WriteLine($"Неизвестный тип объекта '{parts[0]}'");
                        continue;
                }
                newObject.Read(parts);
                heroes.Add(newObject);
                count++;
            }
            Console.WriteLine($"Успешно загружено: {count}");
        }
        static void ShowHeroes()
        {
            if (heroes.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Список персонажей в игре");
            foreach (GameObject item in heroes)
            {
                item.Write();
            }
        }
    }
}
