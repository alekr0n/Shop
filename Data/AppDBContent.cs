using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using Shop.Data.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Shop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public System.Data.Entity.DbSet<Car> Car { get; set; }
        public System.Data.Entity.DbSet<Category> Category { get; set; }
    }
}
