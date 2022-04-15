using curso.API.Business.Entities;

namespace curso.API.Business.Repositories
{
    interface IUsuarioRepositoriy
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
