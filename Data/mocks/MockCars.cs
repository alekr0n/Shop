using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>
                {
                    new Car 
                    { 
                        Name = "Tesla Model S", 
                        ShortDescription = "A fast car", 
                        LongDescription = "A beautiful, fast and very quiet Tesla's car", 
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavourite = true, 
                        available = true, 
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescription = "A quiet and calm",
                        LongDescription = "A comfortable car for urban life",
                        img = "/img/ford_focus.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDescription = "A daring and stylish",
                        LongDescription = "A comfortable car for urban life",
                        img = "/img/m3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mercedes CLS",
                        ShortDescription = "A cozy and large car",
                        LongDescription = "A comfortable car for urban life",
                        img = "/img/mercedes.jpg",
                        price = 55000,
                        isFavourite = false,
                        available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "A silent and economical",
                        LongDescription = "A comfortable car for urban life",
                        img = "/img/nissan-leaf-white.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavouriteCars { get; set; }

        Car IAllCars.GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
