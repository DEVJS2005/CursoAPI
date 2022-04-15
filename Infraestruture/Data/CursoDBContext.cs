using curso.API.Business.Entities;
using curso.API.Infraestruture.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.Infraestruture.Data
{
    public class CursoDBContext : DbContext
    {
        public CursoDBContext(DbContextOptions<DbContext> options) : base(options)
        { 

        
        }

        public CursoDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
