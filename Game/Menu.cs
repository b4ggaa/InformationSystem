using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Menu
    {
        public List<MenuItem> items;
        public Menu() 
        {
            items = new List<MenuItem>();
        }
        public void AddItem(string description, Action callback) 
        {
            items.Add(new MenuItem(description, callback));
        }
        public void Run() 
        {
            while (true) 
            {
                ShowMenu();
                string choice = Console.ReadLine();
                if (choice == "3") 
                {
                    break;
                }
                int number;
                if (!int.TryParse(choice, out number)) 
                {
                    Console.WriteLine("Неизвестная команда");
                    continue;
                }
                int index = number - 1;
                if (index >= 0 && index < items.Count) 
                {
                    items[index].CallBack();
                }
                else 
                {
                    Console.WriteLine("Такого пункта нет");
                }
            }
        }
        public void ShowMenu() 
        {
            Console.WriteLine("Меню");
            for (int i = 0; i < items.Count; i++) 
            {
                int number = i + 1;
                Console.WriteLine($"{number}. {items[i].Description}");
            }
            Console.WriteLine($"{items.Count+1}. Выход");
            Console.WriteLine("Выберите пункт: ");
        }
    }
}
