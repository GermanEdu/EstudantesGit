using EstudantesApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace EstudantesApi.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
