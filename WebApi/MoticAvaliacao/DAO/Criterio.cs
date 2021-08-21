using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Criterio
    {
        public int Codigo { get; set; }
        public int Avaliacao { get; set; }
        public int Nomecriterio { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public double? Nota { get; set; }

        public virtual Avaliacao AvaliacaoNavigation { get; set; }
        public virtual Nomecriterio NomecriterioNavigation { get; set; }
    }
}
