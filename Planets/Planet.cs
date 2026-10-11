using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    internal class Planet
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Radius { get; set; }
        public virtual string GetInfo()
        {
            return $"[Планета] {Name} | Дата открытия: {Date:yyyy.MM.dd} | Радиус: {Radius} км";
        }
    }
}
