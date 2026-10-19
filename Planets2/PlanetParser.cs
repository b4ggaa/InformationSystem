using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class PlanetParser
    {
        private const int MinParts = 4;

        public Planet ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return null;
            }

            string[] parts = line.Split(';');
            if (parts.Length < MinParts)
            {
                throw new FormatException($"Ожидалось минимум {MinParts} поля, получено {parts.Length}");
            }

            string type = parts[0].Trim();
            string name = parts[1].Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FormatException("Пустое имя планеты");
            }

            DateTime date;
            if (!DateTime.TryParse(parts[2].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new FormatException($"Некорректная дата: '{parts[2].Trim()}'");
            }

            double radius;
            if (!double.TryParse(parts[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out radius) || radius < 0)
            {
                throw new FormatException($"Некорректный радиус: '{parts[3].Trim()}'");
            }

            switch (type)
            {
                case "planet":
                    return new Planet { Name = name, Date = date, Radius = radius };

                case "gasgiant":
                    return ParseGasGiant(parts, line, name, date, radius);

                case "exoplanet":
                    return ParseExoplanet(parts, line, name, date, radius);

                default:
                    throw new FormatException($"Неизвестный тип: '{type}'");
            }
        }

        private static GasGiant ParseGasGiant(string[] parts, string line, string name, DateTime date, double radius)
        {
            if (parts.Length < 5)
            {
                throw new FormatException("Для газового гиганта нужно 5 полей");
            }

            int moons;
            if (!int.TryParse(parts[4].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out moons) || moons < 0)
            {
                throw new FormatException($"Некорректное число спутников: '{parts[4].Trim()}'");
            }

            return new GasGiant { Name = name, Date = date, Radius = radius, MoonsCount = moons };
        }

        private static Exoplanet ParseExoplanet(string[] parts, string line, string name, DateTime date, double radius)
        {
            if (parts.Length < 6)
            {
                throw new FormatException("Для экзопланеты нужно 6 полей");
            }

            string starSystem = parts[4].Trim();
            if (string.IsNullOrWhiteSpace(starSystem))
            {
                throw new FormatException("Пустая солнечная система");
            }

            bool habitable;
            if (!bool.TryParse(parts[5].Trim(), out habitable))
            {
                throw new FormatException($"Некорректный флаг IsHabitable: '{parts[5].Trim()}'");
            }

            return new Exoplanet { Name = name, Date = date, Radius = radius, StarSystem = starSystem, IsHabitable = habitable };
        }

        public List<Planet> ParseLines(IEnumerable<string> lines, out List<string> errors, bool skipInvalid = true)
        {
            List<Planet> planets = new List<Planet>();
            errors = new List<string>();
            int lineNumber = 0;

            foreach (string line in lines)
            {
                lineNumber++;
                try
                {
                    Planet planet = ParseLine(line);
                    if (planet != null)
                    {
                        planets.Add(planet);
                    }
                }
                catch (FormatException ex)
                {
                    errors.Add($"Строка {lineNumber}: {ex.Message}");
                    if (!skipInvalid)
                    {
                        throw;
                    }
                }
            }

            return planets;
        }
    }
}
