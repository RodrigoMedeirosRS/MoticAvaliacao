using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Administrador
    {
        public int Codigo { get; set; }
        public int Avaliador { get; set; }

        public virtual Avaliador AvaliadorNavigation { get; set; }
    }
}
