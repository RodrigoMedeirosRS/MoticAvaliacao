using Godot;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface IEscolaBLL
    {
        List<EscolaDTO> ObterEscola();
        void AtualizarEscolas(EscolaDTO escola);
        Node IntanciarEscola(VBoxContainer container);
    }
}