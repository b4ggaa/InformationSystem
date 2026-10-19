using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class PlanetManager
    {
        List<Planet> planets;

        public PlanetManager()
        {
            planets = new List<Planet>();
        }

        public void Add(Planet planet)
        {
            if (planet == null)
            {
                return;
            }
            planets.Add(planet);
        }

        public void AddRange(IEnumerable<Planet> newPlanets)
        {
            if (newPlanets == null)
            {
                return;
            }
            planets.AddRange(newPlanets);
        }

        public bool RemoveByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            string target = name.Trim();
            int index = -1;

            for (int i = 0; i < planets.Count; i++)
            {
                if (string.Equals(planets[i].Name, target, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                return false;
            }

            planets.RemoveAt(index);
            return true;
        }

        public IReadOnlyList<Planet> GetAll()
        {
            return planets.AsReadOnly();
        }

        public int Count
        {
            get { return planets.Count; }
        }

        public void Clear()
        {
            planets.Clear();
        }
    }
}
