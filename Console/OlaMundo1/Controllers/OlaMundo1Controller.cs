using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OlaMundo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlaMundo1Controller : ControllerBase
    {
    
        public OlaMundo1Controller(ILogger<OlaMundo1Controller> logger)
        {
          
        }

        [HttpGet]
        public OlaMundo1 ObterMensagem() 
        {
            var retorno = new OlaMundo1();
            retorno.Mensagem = "Integração do back com o front - no front usamos html e back c#";
            return retorno;
        }
    }
}
