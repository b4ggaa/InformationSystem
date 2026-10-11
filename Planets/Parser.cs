using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    internal class Parser
    {
        public static Planet ParseLine(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length < 4)
            {
                return null;
            }
            string type = parts[0].Trim().ToLower();
            string name = parts[1].Trim();
            DateTime date = DateTime.Parse(parts[2].Trim());
            double radius = double.Parse(parts[3].Trim());
            if (type == "exoplanet" && parts.Length >= 6)
            {
                return new Exoplanet
                {
                    Name = name,
                    Date = date,
                    Radius = radius,
                    StarSystem = parts[4].Trim(),
                    IsHabitable = bool.Parse(parts[5].Trim())
                };
            }
            if (type == "gasgiant" && parts.Length >= 5)
            {
                return new GasGiant
                {
                    Name = name,
                    Date = date,
                    Radius = radius,
                    MoonsCount = int.Parse(parts[4].Trim())
                };
            }
            return new Planet 
            { 
                Name = name, 
                Date = date, 
                Radius = radius 
            };
        }
        public static List<Planet> ParseFile(string filePath)
        {
            var list = new List<Planet>();
            if (!File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                Planet planet = ParseLine(line);
                if (planet != null)
                {
                    list.Add(planet);
                }
            }
            return list;
        }
    }
}
