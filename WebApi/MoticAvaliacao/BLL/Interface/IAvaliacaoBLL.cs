using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface IAvaliacaoBLL
    {
        Task<RetornoDTO<bool>> CadastrarAvalicao(AvaliacaoDTO avaliacaoDTO);
        Task<RetornoDTO<List<AvaliacaoDTO>>> ListarAvaliacoes();
    }
}