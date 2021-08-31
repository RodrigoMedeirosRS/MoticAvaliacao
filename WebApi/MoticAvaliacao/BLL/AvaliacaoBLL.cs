using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    public class AvaliacaoBLL : IAvaliacaoBLL
    {
        private IAvaliacaoDAL DAL { get; set; }
        public AvaliacaoBLL(IAvaliacaoDAL dal)
        {
            DAL = dal;
        }
        public async Task<RetornoDTO<bool>> CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            DAL.CadastrarAvaliacao(avaliacaoDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            DAL.RemoverAvaliacao(avaliacaoDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<List<AvaliacaoDTO>>> ListarAvaliacoes()
        {
            var avalicoes = DAL.ListarAvalicoes();
            return new RetornoDTO<List<AvaliacaoDTO>>()
            {
                Conteudo = avalicoes
            };
        }
    }
}