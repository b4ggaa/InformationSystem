using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Archer : GameObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Range { get; set; }
        public Archer() { }
        public void Read(string[] properties)
        {
            Name = properties[1];
            Health = int.Parse(properties[2]);
            Range = int.Parse(properties[3]);
        }
        public void Write()
        {
            Console.WriteLine($"[Лучник] Имя: {Name}, Здоровье: {Health}, Дальность: {Range}");
        }
    }
}
