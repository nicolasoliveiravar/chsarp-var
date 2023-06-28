using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPiPessoa.Application.Usuario
{
    public class UsuarioRequest
    {
        public int id { get; set; }
        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}
