using System.Collections.Generic;

namespace DTO
{
    public class RetornoListagemAvaliacoesDTO
    {
        public RetornoListagemAvaliacoesDTO()
        {
            AvaliadosPorCategoria = new List<List<AvaliacaoDTO>>();
            NaoAvaliados = new List<AvaliacaoDTO>();
        }
        public List<List<AvaliacaoDTO>> AvaliadosPorCategoria { get ; set; }
        public List<AvaliacaoDTO> NaoAvaliados { get; set; }        
    }
}