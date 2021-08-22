using System;
using System.Collections.Generic;

#nullable disable

namespace DAO
{
    public partial class Avaliador
    {
        public Avaliador()
        {
            Administradors = new HashSet<Administrador>();
            Avaliacaos = new HashSet<Avaliacao>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }
    }
}
