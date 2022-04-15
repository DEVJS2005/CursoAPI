using Curso.API.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.API.Configurations
{
    public interface IAuthenticationService
    {
        object GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
