using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("CadastrarAvalicao")]
        public async Task<RetornoDTO<bool>> CadastrarAvalicao(AvaliacaoDTO avaliacaoDTO)
        {
            return Requisicao.ExecutarRequisicao<AvaliacaoDTO, bool>(avaliacaoDTO, BLL.CadastrarAvalicao).Result;
        }

        [HttpPost("ListarAvaliacoes")]
        public async Task<RetornoDTO<List<AvaliacaoDTO>>> ListarAvaliacoes(ValorDTO qualquerCoisa = null)
        {
            return Requisicao.ExecutarRequisicao<List<AvaliacaoDTO>>(BLL.ListarAvaliacoes).Result;
        }
    }
}