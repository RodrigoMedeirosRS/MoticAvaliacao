using Godot;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface ICategoriaBLL
    {
        List<CategoriaDTO> ObterCategorias();
        void AtualizarCategorias(CategoriaDTO categoria);
        Node IntanciarCategoria(VBoxContainer container);
    }
}