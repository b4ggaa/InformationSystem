using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class GasGiant : Planet
    {
        public int MoonsCount { get; set; }

        public override string GetInfo() 
        {
            return $"[Газовый гигант] {Name} | Спутников: {MoonsCount} | Дата открытия: {Date:yyyy.MM.dd} | Радиус: {Radius} км";
        }
           
    }
}
