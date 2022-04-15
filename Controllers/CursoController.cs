using Curso.API.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.API.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    
    public class CursoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um curso", Type = typeof(CursoViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CursoViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
         public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModelOutput>();
           // var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            cursos.Add(new CursoViewModelOutput()
            {
                Login = "",
                Descricao = "teste",
                Nome = "teste"

            });

            return Ok(cursos);
        }
    }
}
