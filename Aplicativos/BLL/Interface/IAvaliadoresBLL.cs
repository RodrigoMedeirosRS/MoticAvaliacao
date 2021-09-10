using Godot;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface IAvaliadoresBLL
    {
        List<AvaliadorDTO> ObterAvaliadores();
        void AtualizarAvaliadores(AvaliadorDTO avaliador);
        void AtualizarAcessoAdmin(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO);
        Node IntanciarAvalaidores(VBoxContainer container);
    }
}