using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Mag : GameObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public Mag() { }
        public void Read(string[] properties)
        {
            Name = properties[1];
            Health = int.Parse(properties[2]);
            Mana = int.Parse(properties[3]);
        }
        public void Write()
        {
            Console.WriteLine($"[Маг] Имя: {Name}, Здоровье: {Health}, Мана: {Mana}");
        }
    }
}
