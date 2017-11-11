namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');
                string carModel = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int caroWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tierOnePressure = double.Parse(carInfo[5]);
                int tierOneAge = int.Parse(carInfo[6]);
                double tierTwoPressure = double.Parse(carInfo[7]);
                int tierTwoAge = int.Parse(carInfo[8]);
                double tierThreePressure = double.Parse(carInfo[9]);
                int tierThreeAge = int.Parse(carInfo[10]);
                double tierFourPressure = double.Parse(carInfo[11]);
                int tierFourAge = int.Parse(carInfo[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(caroWeight, cargoType);
                Tire firstTier = new Tire(tierOnePressure, tierOneAge);
                Tire secondTier = new Tire(tierTwoPressure, tierTwoAge);
                Tire thirdTier = new Tire(tierThreePressure, tierThreeAge);
                Tire fourthTier = new Tire(tierFourPressure, tierFourAge);

                Car car = new Car(carModel, engine, cargo, new List<Tire>());
                car.AddTire(firstTier);
                car.AddTire(secondTier);
                car.AddTire(thirdTier);
                car.AddTire(fourthTier);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var validCars =
                    cars.Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(tier => tier.Pressure < 1));

                foreach (var validCar in validCars)
                {
                    Console.WriteLine(validCar.Model);
                }
            }
            else if (command == "flamable")
            {
                var validCars = cars.Where(car => car.Cargo.Type == "flamable" && car.Engine.Power > 250);

                foreach (var validCar in validCars)
                {
                    Console.WriteLine(validCar.Model);
                }
            }
        }
    }
}