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
                        img = "https://storage.carsmile.pl/uploads/2023/09/thumb_tesla_model_s.jpg", 
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
                        img = "https://f.evomagazine.pl/evo_prod_2022_02/thumb-article-183-t1.jpg?v=93e8724a807b6e9e59b5196f55e07ada",
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
                        img = "https://ocdn.eu/pulscms-transforms/1/vQ3ktkpTURBXy8yN2M1YTc4MDE0YTk1ODc5M2EwMWE0YTY5YWI0ZmY3MC5qcGeSlQPM780B6c0Kf80F55MFzQSwzQKj",
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
                        img = "https://autostore.pl/images/page_images/foto_main/1266/autostore-mb-cls-coupe-01.jpg",
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
                        img = "https://masterlease.pl/wp-content/uploads/2021/06/nissan-leaf-white.jpg",
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
