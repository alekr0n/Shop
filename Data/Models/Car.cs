using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string img { get; set; }

        public ushort price { get; set; }

        public bool isFavourite { get; set; }

        public bool available { get; set; } // наличие товара (на складе)

        public int categoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
