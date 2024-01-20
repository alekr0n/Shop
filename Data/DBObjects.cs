using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content) 
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), "The parameter 'content' cannot be null.");
            }

            try
            {
                if (!content.Category.Any())
                {
                    content.Category.AddRange(Categories.Select(c => c.Value));
                }

                content.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Вывести информацию об исключении в консоль для дополнительного анализа
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                Console.WriteLine($"InnerException: {ex.InnerException?.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Передать исключение дальше, если нужно
                throw;
            }
            catch (Exception ex)
            {
                // Вывести информацию об исключении в консоль для дополнительного анализа
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Передать исключение дальше, если нужно
                throw;
            }

            //if (!content.Category.Any())
            //    content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDescription = "A fast car",
                        LongDescription = "A beautiful, fast and very quiet Tesla's car",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Electrocars"]
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
                        Category = Categories["Default cars"]
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
                        Category = Categories["Default cars"]
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
                        Category = Categories["Default cars"]
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
                        Category = Categories["Electrocars"]
                    }
                    );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Electrocars", categoryDescription = "Modern mode of transport"},
                        new Category { categoryName = "Default cars", categoryDescription = "Cars with ICE"}
                    };

                    _categories = new Dictionary<string, Category>();
                    foreach(Category el in list)
                        _categories.Add(el.categoryName, el);
                }

                return _categories;
            }
        }
    }
}
