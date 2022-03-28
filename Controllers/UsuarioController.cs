﻿using Curso.API.Filters;
using Curso.API.Models;
using Curso.API.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Curso.API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
          

        [SwaggerResponse(statusCode: 200,description:"Sucesso ao autenticar o usuário.", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios a serem preenchidos.",Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno.", Type = typeof(ErroGenericoViewModel))]

        //Retornos disponiveis dentro da construção de API's são:  BadRequest são (400),NotFound(404), Ok(200) e  Created (201).
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizada]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuarioViewModelOutput = new usuarioViewModelOutput()
            {
                Codigo = 1,
                LoginViewModelInput = "JS",
                Email = "JS@gmail.com"
            };


            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>19$Es (XISg;ef15sbk: jH\\2.)8ZP'qY#7");
            var SymmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[])
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
                }
            };
            
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizada]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }
    }
}
