using CarLibraryClass;
using System;
using System.Collections.Generic;
using System.Diagnostics; 

namespace ObligatoriskOpg1_4REST.Manager
{
    public class CarManager
    {
        private static int id_counter = 100;
        private static readonly List<Car> carList = new List<Car>()
        {
            new Car(){Id = 1, Model = "12345", LicensePlate = "12345", Price = 1000},
            new Car(){Id = 2, Model = "12345", LicensePlate = "12346", Price = 1001},
            new Car(){Id = 3, Model = "12345", LicensePlate = "12347", Price = 1002}
        };

        public List<Car> GetAllCars()
        {
            List<Car> result = new List<Car>(carList);
            return result;
        }

        public Car GetCarById(int id)
        {
            return carList.Find(car => car.Id == id);
        }

        public Car Add(Car newCar)
        {
            id_counter++;
            newCar.Id = id_counter;
            carList.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = carList.Find(car => car.Id == id);
            if (car == null) return null;
            carList.Remove(car);
            return car;
        }

        public Car Update(int id, Car update)
        {
            Car car = carList.Find(car => car.Id == id);
            if (car == null) return null;
            car.Model = update.Model;
            car.LicensePlate = update.LicensePlate;
            car.Price = update.Price;
            return car;
        }

    }
}
