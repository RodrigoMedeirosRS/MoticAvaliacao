using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("motic/[controller]")]
    public class Avaliacao : ControllerBase
    {
        [HttpPost("Teste")]
        public async Task<RetornoDTO<string>> Teste(string Conteudo)
        {
            return new RetornoDTO<string>
            {
                Mensagem = "Sucesso",
                Sucesso = true,
                Conteudo = "Ola Mundo!"
            };
        }
    }
}