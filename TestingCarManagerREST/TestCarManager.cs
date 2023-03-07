using CarLibraryClass;
using ObligatoriskOpg1_4REST.Manager;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace TestingCarManagerREST
{
    public class TestCarManager
    {
        CarManager carManager = new CarManager();

        [Fact]
        public void TestCarAdd()
        {
            
            Car newCar = new Car() { Id = 1, Model = "newCar123vroomvroom", LicensePlate = "12345", Price = 1000 };
            carManager.Add(newCar);
            List<Car> MyCarList = carManager.GetAllCars();

            Car addedCar = MyCarList.Find(c => c.Model == "newCar123vroomvroom");
            Assert.NotNull(addedCar);
        }

        [Fact]
        public void TestCarRemove()
        {
            carManager.Delete(1);

            List<Car> MyCarList = carManager.GetAllCars();
            Car addedCar = MyCarList.Find(c => c.Id == 1);
            Assert.Null(addedCar);
        }
    }
}
