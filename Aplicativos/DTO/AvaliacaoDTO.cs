using System.Collections.Generic;

namespace DTO
{
    public class AvaliacaoDTO
    {
        public int Codigo { get; set ;}
        public double Total { get; set; }
        public AvaliadorDTO Avaliador { get; set; }
        public TrabalhoDTO Trabalho { get; set; }
        public List<CriterioAvaliadoDTO> CritariosAvaliados { get; set; }
    }
}