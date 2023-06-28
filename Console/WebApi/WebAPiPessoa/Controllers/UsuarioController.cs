using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using WebAPiPessoa.Application.Autenticacao;
using WebAPiPessoa.Application.Pessoa;
using WebAPiPessoa.Application.Usuario;
using WebAPiPessoa.Repository;
using System.Collections.Generic;

namespace WebAPiPessoa.Controllers
{
    [apicontroller]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
       
        private readonly PessoaContext _context;

        public UsuarioController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirUsuario([FromBody] UsuarioRequest request)
        {
            var usuarioServices = new UsuarioService(_context);
            var sucesso = usuarioServices.InserirUsuario(request);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ObterUsuarios()
        {
            var usuarioServices = new UsuarioService(_context);
            var usuarios = usuarioServices.ObterUsuarios();

            if (usuarios == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(usuarios);
            }
        }

        [HttpGet]
        [Route("(id)")]
        [Authorize]
        public IActionResult ObterUsuario([FromRoute] int id)
        {
            var usuarioServices = new UsuarioService(_context);
            var usuario = usuarioServices.ObterUsuario(id);

            if (usuario == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] UsuarioRequest request)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.AtualizarUsuario(id, request);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]

        public IActionResult RemoverUsuario([FromRoute] int id)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.RemoverUsuario(id);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
    [HttpPost]
    [Authorize]
    public List<UsuarioResponse> UsuarioPessoa()
    {
        var usuarioService = new UsuarioService(_context);
        var pessoas = usuarioService.UsuarioPessoa();

        return pessoas;
    }
}
