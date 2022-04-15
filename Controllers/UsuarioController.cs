using curso.API.Business.Entities;
using curso.API.Business.Repositories;
using curso.API.Configurations;
using curso.API.Infraestruture.Data.Repositories;
using Curso.API.Filters;
using Curso.API.Infraestruture.Data;
using Curso.API.Models;
using Curso.API.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Curso.API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositoriy _usuarioRepositoriy;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(
            IUsuarioRepositoriy usuarioRepositoriy,
            IConfiguration configuration, 
            IAuthenticationService authenticationService)
        {
            _usuarioRepositoriy = usuarioRepositoriy;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200,description:"Sucesso ao autenticar o usuário.", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios a serem preenchidos.",Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno.", Type = typeof(ErroGenericoViewModel))]

        //Retornos disponiveis dentro da construção de API's são:  BadRequest são (400),NotFound(404), Ok(200) e  Created (201).
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizada]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            Usuario usuario = _usuarioRepositoriy.ObterUsuario(loginViewModelInput.Login);
            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            //if (usuario.Senha != loginViewModel.Senha.GerarSenhaCriptografada())
            //{
            //    return BadRequest("Houve um erro ao tentar acessar.");
            //}

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);


            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput

            }) ;
        }
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao cadastrar o usuário.", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios a serem preenchidos.", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno.", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizada]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();
            //optionsBuilder.UseSqlServer("Server=localhost;Database=CURSO;user=root;password=");
            //CursoDBContext contexto = new CursoDBContext(optionsBuilder.Options);

            //var migracoesPendentes = contexto.Database.GetPendingMigrations();

            //if(migracoesPendentes.Count() > 0)
            //{
            //   contexto.Database.Migrate();
            //}

            var usuario = new Usuario();
            usuario.Login = loginViewModelInput.Login;
            usuario.Senha = loginViewModelInput.Senha;
            usuario.Email = loginViewModelInput.Email;
            _usuarioRepositoriy.Adicionar(usuario);
            _usuarioRepositoriy.Commit();

            return Created("", loginViewModelInput);
        }
    }
}
