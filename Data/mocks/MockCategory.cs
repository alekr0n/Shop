using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Electrocars", categoryDescription = "Modern mode of transport"},
                    new Category { categoryName = "Default cars", categoryDescription = "Cars with ICE"}
                };
            }
        }
    }
}
