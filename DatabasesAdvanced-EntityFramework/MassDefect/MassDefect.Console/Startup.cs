namespace MassDefect.Console
{
    using MassDefect.Data;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Startup
    {
        private static void Main()
        {
            MassDefectContext context = new MassDefectContext();

            ImportSolarSystems();
            ImportStars();
            ImportPlanets();
            ImportPersons();
            ImportAnomalies();
            ImportAnomalyVictims();
        }

        private static void ImportAnomalies()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);

            foreach (var anomaly in anomalies)
            {
                if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var anomalyEntity = new Anomalies()
                {
                    //OriginPlanet = context.Anomalies.Select(orp => orp.OriginPlanet.Name),
                    //TeleportPlanet = context.Anomalies.Select(tpl => tpl.TeleportPlanet.Name)
                };

                context.Anomalies.Add(anomalyEntity);
                System.Console.WriteLine($"Successfully imported {anomalyEntity} {anomalyEntity.OriginPlanet} {anomalyEntity.TeleportPlanet}.");
            }

            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PersonsPath);
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);

            foreach (var person in persons)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var personEntity = new Persons()
                {
                    Name = person.Name,
                    //HomePlanet = context.Persons.Select(hmp => hmp.HomePlanet.Name)
                };

                context.Persons.Add(personEntity);
                System.Console.WriteLine($"Successfully imported {personEntity} {personEntity.Name} {personEntity.HomePlanet}.");
            }

            context.SaveChanges();
        }

        private static void ImportPlanets()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PlanetsPath);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);

            foreach (var planet in planets)
            {
                if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var planetEntity = new Planets()
                {
                    Name = planet.Name,
                    //SolarSystem = context.Planets.Select(slr => slr.SolarSystem.Name),
                    //Sun = context.Planets.Select(sun => sun.Sun.Name)
                };

                context.Planets.Add(planetEntity);
                System.Console.WriteLine($"Successfully imported {planetEntity} {planetEntity.Name} {planetEntity.SolarSystem} {planetEntity.Sun}.");
            }

            context.SaveChanges();
        }

        private static void ImportAnomalyVictims()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimsDTO>>(json);

            foreach (var anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var anomalyVictimEntity = new AnomalyVictimsDTO()
                {
                    Id = anomalyVictim.Id,
                    Person = anomalyVictim.Person
                };
            }
        }

        private static void ImportStars()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(StarsPath);
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (var star in stars)
            {
                if (star.Name == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var starEntity = new Stars()
                {
                    Name = star.Name,
                    //SolarSystem = context.Stars.Select(sls => sls.SolarSystem.Name)
                };

                //if (starEntity.SolarSystem == null)
                //{
                //    throw new ArgumentException("Error: Invalid data.");
                //    continue;
                //}

                context.Stars.Add(starEntity);
                System.Console.WriteLine($"Successfully imported {starEntity}.");
            }
        }

        private static void ImportSolarSystems()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(SolarSystemsPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    throw new ArgumentException("Error: Invalid data.");
                    continue;
                }

                var solarSystemEntity = new SolarSystems()
                {
                    Name = solarSystem.Name
                };

                context.SolarSystems.Add(solarSystemEntity);
                System.Console.WriteLine($"Successfully imported {solarSystemEntity} {solarSystemEntity.Name}.");
            }

            context.SaveChanges();
        }

        private const string SolarSystemsPath = "C:/Users/programigo/Desktop/datasets/solar-systems.json";

        private const string StarsPath = "C:/Users/programigo/Desktop/datasets/stars.json";

        private const string PlanetsPath = "C:/Users/programigo/Desktop/datasets/planets.json";

        private const string PersonsPath = "C:/Users/programigo/Desktop/datasets/persons.json";

        private const string AnomaliesPath = "C:/Users/programigo/Desktop/datasets/anomalies.json";

        private const string AnomalyVictimsPath = "C:/Users/programigo/Desktop/datasets/anomaly-victims.json";
    }
}