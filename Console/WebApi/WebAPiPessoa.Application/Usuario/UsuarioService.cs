using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using WebAPiPessoa.Application.Autenticacao;
using WebAPiPessoa.Application.Pessoa;
using WebAPiPessoa.Repository;
using WebAPiPessoa.Repository.Models;

namespace WebAPiPessoa.Application.Usuario
{
    public class UsuarioService
    {
        private readonly PessoaContext _context;

        public UsuarioService(PessoaContext context)
        {
            _context = context;
        }

        public List<UsuarioResponse> UsuarioPessoa()
        {
            var usuarioDb = _context.Pessoa.ToList();
            var pessoas = new List<UsuarioResponse>();

            foreach (var item in usuarioDb)
            {
                pessoas.Add(new UsuarioResponse()
                {
                    id = item.id,
                    Nome = item.nome,
                    Usuario = item.usurio,
                    Senha = item.senha,
                    senha= item.senha,
                });
            }

            return pessoas;
        }
        public bool InserirUsuario(UsuarioRequest request)
        {
            try
            {
                var usuario = new TabUsuario()
                {
                    id = request.id,
                    nome = request.Nome,
                    usuario = request.Usuario,
                    senha = request.Senha
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
            
        }

        public List<TabUsuario> ObterUsuarios()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                return usuarios;
            }
            catch(Exception ex)
            {
                return null;
            } 
        }

        public TabUsuario ObterUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(x => x.id == id);
                return usuario;
            }
            catch(Exception ex)
            {
                return null;
            }   
        }

        public bool AtualizarUsuario(int id, UsuarioRequest request)
        {
            try
            {
                var usuarioDb = _context.Usuarios.FirstOrDefault(x => x.id == id);
                if (usuarioDb == null)
                    return false;

                usuarioDb.nome = request.Nome;
                usuarioDb.senha = request.Senha;
                usuarioDb.usuario = request.Usuario;

                _context.Usuarios.Update(usuarioDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoverUsuario(int id)
        {
            try
            {
                var usuarioDb = _context.Usuarios.FirstOrDefault(x => x.id == id);
                if (usuarioDb == null)
                    return false;

                _context.Usuarios.Remove(usuarioDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
