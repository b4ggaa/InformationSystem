using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Swordman : GameObject
    {
        public string Name { get; set; } 
        public int Health { get; set; }
        public int Armor {  get; set; }
        public Swordman() {}
        public void Read(string[] properties)
        {
            Name = properties[1];
            Health = int.Parse(properties[2]);
            Armor = int.Parse(properties[3]);
        }
        public void Write()
        {
            Console.WriteLine($"[Мечник] Имя: {Name}, Здоровье: {Health}, Броня: {Armor}");
        }
    }
}
