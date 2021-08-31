using System.Collections.Generic;

using DTO;

namespace DAL.Interface
{
    public interface IAvaliacaoDAL
    {
        void CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO);
        List<AvaliacaoDTO> ListarAvalicoes();
        void RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO);
    }
}