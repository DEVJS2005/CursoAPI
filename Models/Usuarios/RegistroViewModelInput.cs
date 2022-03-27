using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.API.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        //Modelo de entrada para Registrar-se
        //Required significa que a propriedade é de escrita obrigatória. Ou seja tem que preencher
        [Required(ErrorMessage = "O login é obrigatório") ]
        public string Login  { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
