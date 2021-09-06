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
    public class EscolaBLL : IEscolaBLL
    {
        private IRequisicao SAL { get ; set; }
        public EscolaBLL()
        {
            SAL = new Requisicao();
        }
        public List<EscolaDTO> ObterEscola()
        {
            var retorno = SAL.ExecutarPost<ValorDTO, RetornoDTO<List<EscolaDTO>>>(Apontamentos.ListaEscolas, new ValorDTO());
            return retorno.Conteudo;
        }
        public void AtualizarEscolas(EscolaDTO escola)
        {
            SAL.ExecutarPost<EscolaDTO, RetornoDTO<bool>>(Apontamentos.CadastrarEscolas, escola);
        }
        public Node IntanciarEscola(VBoxContainer container)
        {
            var cena = InstanciadorUtil.CarregarCena("res://RES/Cenas/Criterio.tscn");
            return InstanciadorUtil.InstanciarObjeto(container, cena, null);
        }
    }
}