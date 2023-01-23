using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("Relacionamento") { }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Carro> Carros { get; set; }

    }       
}

