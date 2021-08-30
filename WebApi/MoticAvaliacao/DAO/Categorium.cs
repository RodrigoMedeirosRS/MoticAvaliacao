using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Categorium
    {
        public Categorium()
        {
            Trabalhos = new HashSet<Trabalho>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Trabalho> Trabalhos { get; set; }
    }
}
