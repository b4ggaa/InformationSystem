using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    internal class Menu
    {
        private List<MenuItem> items;
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

                Console.WriteLine("Выберите команду: ");
                string choice = Console.ReadLine();
                if (choice == "0") { break; }
                if (choice == null) 
                {
                    choice = string.Empty;
                }
                ExecuteCommand(choice);
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nМеню выбора");
            for (int i = 0; i < items.Count; i++)
            {
                int number = i + 1;
                Console.WriteLine($"{number}. {items[i].Description}");
            }
            Console.WriteLine("0 Выход");
            Console.Write("Выберите команду: ");
        }
        public void ExecuteCommand(string choice)
        {
            try
            {
                int number;
                if (!int.TryParse(choice, out number))
                {
                    Console.WriteLine("Неизвестная команда. Введите число.");
                    return;
                }

                if (number == 0) return;

                int index = number - 1;
                if (index >= 0 && index < items.Count)
                {
                    items[index].CallBack();
                }
                else
                {
                    Console.WriteLine("Пункта с таким номером не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
