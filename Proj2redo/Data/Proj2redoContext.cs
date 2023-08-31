using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proj2redo.Data
{
    public class Proj2redoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Proj2redoContext() : base("name=Proj2redoContext")
        {
        }

        public System.Data.Entity.DbSet<Proj2redo.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Proj2redo.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Proj2redo.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Proj2redo.Models.OrderDetails> OrderDetails { get; set; }
    }
}
