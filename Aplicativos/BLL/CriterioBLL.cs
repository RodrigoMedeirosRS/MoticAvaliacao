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
    public class CriterioBLL : ICriterioBLL
    {
        private IRequisicao SAL { get ; set; }
        public CriterioBLL()
        {
            SAL = new Requisicao();
        }
        public List<CriterioDTO> ObterCriterios()
        {
            var retorno = SAL.ExecutarPost<ValorDTO, RetornoDTO<List<CriterioDTO>>>(Apontamentos.ListaCriterios, new ValorDTO());
            return retorno.Conteudo;
        }
        public void AtualizarCriterios(CriterioDTO criterio)
        {
            SAL.ExecutarPost<CriterioDTO, RetornoDTO<bool>>(Apontamentos.CadastrarCriterio, criterio);
        }
        public Node IntanciarCriterio(VBoxContainer container)
        {
            var cena = InstanciadorUtil.CarregarCena("res://RES/Cenas/Criterio.tscn");
            return InstanciadorUtil.InstanciarObjeto(container, cena, null);
        }
    }
}