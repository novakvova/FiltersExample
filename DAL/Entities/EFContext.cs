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

        
    }

   
}