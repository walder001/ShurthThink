using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shurth.Entidades;

namespace Shurth.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cargos> Cargos { get; set; }

        public Contexto() : base("ShurthDb")
        { }
    }
}
