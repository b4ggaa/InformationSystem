using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    internal class PlanetManager
    {
        private readonly List<Planet> _planets = new List<Planet>();

        public void Add(Planet planet)
        {
            if (planet != null) _planets.Add(planet);
        }

        public void AddRange(List<Planet> newPlanets)
        {
            _planets.AddRange(newPlanets);
        }

        public bool RemoveByName(string name)
        {
            int index = _planets.FindIndex(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                _planets.RemoveAt(index);
                return true;
            }
            return false;
        }

        public List<Planet> GetAll()
        {
            return _planets;
        }
    }
}
