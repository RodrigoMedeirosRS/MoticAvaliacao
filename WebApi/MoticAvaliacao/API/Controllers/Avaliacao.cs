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

        [HttpPost("CadastrarAvaliacao")]
        public async Task<RetornoDTO<bool>> CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            return Requisicao.ExecutarRequisicao<AvaliacaoDTO, bool>(avaliacaoDTO, BLL.CadastrarAvaliacao).Result;
        }

        [HttpPost("RemoverAvaliacao")]
        public async Task<RetornoDTO<bool>> RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            return Requisicao.ExecutarRequisicao<AvaliacaoDTO, bool>(avaliacaoDTO, BLL.RemoverAvaliacao).Result;
        }

        [HttpPost("ListarAvaliacoes")]
        public async Task<RetornoDTO<RetornoListagemAvaliacoesDTO>> ListarAvaliacoes(ValorDTO qualquerCoisa = null)
        {
            return Requisicao.ExecutarRequisicao<RetornoListagemAvaliacoesDTO>(BLL.ListarAvaliacoes).Result;
        }
    }
}