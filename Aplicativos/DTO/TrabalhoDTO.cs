using System;

namespace DTO
{
    public class TrabalhoDTO
    {
        public string Nome { get; set; }
        public DateTime AnoApresentacao { get ; set; }
        public EscolaDTO Escola { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}