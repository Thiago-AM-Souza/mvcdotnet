using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorioFilmes.Models
{
    public class Context : DbContext
    {
        public DbSet<Repositorio> Repositorio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Filmes;Trusted_Connection=True;");
        }
    }
}
