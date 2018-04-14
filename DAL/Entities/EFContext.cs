using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public class EFContext : DbContext
    {
        
        public EFContext()
            : base("name=ShopSemenConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilterName> FilterNames { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<FilterNameGroup> FilterNameGroups { get; set; }


    }

   
}