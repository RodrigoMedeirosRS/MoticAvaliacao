using Godot;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface ICriterioBLL
    {
        List<CriterioDTO> ObterCriterios();
        void AtualizarCriterios(CriterioDTO categoria);
        Node IntanciarCriterio(VBoxContainer container);
    }
}