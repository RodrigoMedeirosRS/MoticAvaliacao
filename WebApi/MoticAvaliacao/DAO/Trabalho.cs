using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Trabalho
    {
        public Trabalho()
        {
            Avaliacaos = new HashSet<Avaliacao>();
        }

        public int Codigo { get; set; }
        public int Escola { get; set; }
        public int Categoria { get; set; }
        public string Nome { get; set; }
        public DateTime Anoapresentacao { get; set; }

        public virtual Categorium CategoriaNavigation { get; set; }
        public virtual Escola EscolaNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }
    }
}
