using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Nomecriterio
    {
        public Nomecriterio()
        {
            Criterios = new HashSet<Criterio>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Criterio> Criterios { get; set; }
    }
}
