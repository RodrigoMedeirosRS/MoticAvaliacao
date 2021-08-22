using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DTO;
using API.Interface;
using BLL.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("motic/[controller]")]
    public class Avaliacao : ControllerBase
    {
        private IAvaliacaoBLL BLL { get; set; }
        private IRequisicao Requisicao { get; set; }
        public Avaliacao(IAvaliacaoBLL bll, IRequisicao requisicao)
        {
            BLL = bll;
            Requisicao = requisicao;
        }

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