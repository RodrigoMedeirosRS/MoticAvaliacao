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
        public async Task<RetornoDTO<bool>> CadastrarAvalicao(AvaliacaoDTO avaliacaoDTO)
        {
            DAL.CadastrarAvalicao(avaliacaoDTO);
            return new RetornoDTO<bool>();
        }
        public async Task<RetornoDTO<List<AvaliacaoDTO>>> ListarAvaliacoes()
        {
            return new RetornoDTO<List<AvaliacaoDTO>>();
        }
    }
}