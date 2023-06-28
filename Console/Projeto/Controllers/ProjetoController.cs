using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        public ProjetoController(ILogger<ProjetoController> logger)
        {

        }

        [HttpGet]
        public ProjetoRequest ObterMensagem()
        {
            var retorno = new ProjetoRequest();
            retorno.Mensagem = "Olá mundo - Essa é minha primeira web API";
            return retorno;
        }
    }
}
