using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface IAvaliacaoBLL
    {
        Task<RetornoDTO<bool>> CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO);
        Task<RetornoDTO<bool>> RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO);
        Task<RetornoDTO<List<AvaliacaoDTO>>> ListarAvaliacoes();
    }
}