using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Escola
    {
        public Escola()
        {
            Trabalhos = new HashSet<Trabalho>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Trabalho> Trabalhos { get; set; }
    }
}
