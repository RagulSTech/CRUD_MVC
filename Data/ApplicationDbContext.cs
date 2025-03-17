using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUDOperationMVC.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext() : base("name=connection_Db")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}