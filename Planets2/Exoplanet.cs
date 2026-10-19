using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class Exoplanet : Planet
    {
        public string StarSystem { get; set; } = string.Empty;
        public bool IsHabitable { get; set; }

        public override string GetInfo() 
        {
            return $"[Экзопланета] {Name} | Солнечная система: {StarSystem} | Пригодна для жизни: {IsHabitable} | Дата открытия: {Date:yyyy.MM.dd} | " +
            $"Радиус: {Radius} км";
        }
    }
}
