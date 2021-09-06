using Godot;
using System.Collections.Generic;

using DTO;
using SAL;
using BLL.Utils;
using BLL.Interface;
using SAL.Interface;
using BLL.Constantes;

namespace BLL
{
    public class CategoriaBLL : ICategoriaBLL
    {
        private IRequisicao SAL { get; set; }
        public CategoriaBLL()
        {
            SAL = new Requisicao();
        }
        public List<CategoriaDTO> ObterCategorias()
        {
            var retorno = SAL.ExecutarPost<ValorDTO, RetornoDTO<List<CategoriaDTO>>>(Apontamentos.ListarCategorias, new ValorDTO());
            return retorno.Conteudo;
        }
        public void AtualizarCategorias(CategoriaDTO categoria)
        {
            SAL.ExecutarPost<CategoriaDTO, RetornoDTO<bool>>(Apontamentos.CadastrarCategoria, categoria);
        }
        public Node IntanciarCategoria(VBoxContainer container)
        {
            var cena = InstanciadorUtil.CarregarCena("res://RES/Cenas/Categoria.tscn");
            return InstanciadorUtil.InstanciarObjeto(container, cena, null);
        }
    }
}