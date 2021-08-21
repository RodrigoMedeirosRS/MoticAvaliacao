using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Criterios = new HashSet<Criterio>();
        }

        public int Codigo { get; set; }
        public int Avaliador { get; set; }
        public int Trabalho { get; set; }

        public virtual Avaliador AvaliadorNavigation { get; set; }
        public virtual Trabalho TrabalhoNavigation { get; set; }
        public virtual ICollection<Criterio> Criterios { get; set; }
    }
}
