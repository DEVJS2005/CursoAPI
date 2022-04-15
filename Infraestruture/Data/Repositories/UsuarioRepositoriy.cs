using curso.API.Business.Entities;
using curso.API.Business.Repositories;
using Curso.API.Infraestruture.Data;
using System.Linq;

namespace curso.API.Infraestruture.Data.Repositories
{
    public class usuarioRepositoriy : IUsuarioRepositoriy
    {
       private readonly CursoDBContext _contexto;

        public usuarioRepositoriy(CursoDBContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return  _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
