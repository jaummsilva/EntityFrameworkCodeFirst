using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MvcContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}