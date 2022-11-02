using Assignment7.Models;
using Cars.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            //QueryData();
        }

        private static void QueryData()
        {
            var context = new CarContext();

            var query = context.Cars
                .Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name);
            //var query = from car ins context.Cars
            //            orderby car.Combined descending, car.Name
            //            select car;

            //var query = context.Cars
            //    .OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarContext();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
            }
            db.SaveChanges();
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }
    }
}
