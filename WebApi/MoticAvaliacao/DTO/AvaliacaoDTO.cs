using System.Collections.Generic;

namespace DTO
{
    public class AvaliacaoDTO
    {
        public AvaliadorDTO Avaliador { get; set; }
        public TrabalhoDTO TrabalhoDTO { get; set; }
        public List<CriterioDTO> CritariosAvaliados { get; set; }
    }
}