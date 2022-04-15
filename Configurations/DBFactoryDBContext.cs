using Curso.API.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace curso.API.Configurations
{
    public class DBFactoryDBContext : IDesignTimeDbContextFactory<CursoDBContext>
    {
        public CursoDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CURSO;user=root;password=");
            CursoDBContext contexto = new CursoDBContext(optionsBuilder.Options);
            
            return contexto;
        }
    }
}
