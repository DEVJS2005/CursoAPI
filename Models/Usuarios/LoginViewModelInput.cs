using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.API.Models.Usuarios
{
    public class LoginViewModelInput
    {
        //Modelo de entrada para login!
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "O Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
