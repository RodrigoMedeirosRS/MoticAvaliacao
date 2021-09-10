using Godot;
using System.Collections.Generic;

using DTO;
using BLL.Utils;
using BLL.Interface;
using BLL.Constantes;
using SAL;
using SAL.Interface;

namespace BLL
{
    public class AvaliadoresBLL : IAvaliadoresBLL
    {
        private IRequisicao SAL { get; set; }
        public AvaliadoresBLL()
        {
            SAL = new Requisicao();
        }
        public List<AvaliadorDTO> ObterAvaliadores()
        {
            var retorno = SAL.ExecutarPost<ValorDTO, RetornoDTO<List<AvaliadorDTO>>>(Apontamentos.ListarAvaliadores, new ValorDTO()
            {
                Valor = Apontamentos.ChaveDeAcesso
            });
            return retorno.Conteudo;
        }
        public void AtualizarAcessoAdmin(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO)
        {
            SAL.ExecutarPost<AlterarAcessoAdministradorDTO, RetornoDTO<bool>>(Apontamentos.AlterarAcessoAdministrador, alterarAcessoAdministradorDTO);
        }
        public void AtualizarAvaliadores(AvaliadorDTO avaliador)
        {
            SAL.ExecutarPost<AvaliadorDTO, RetornoDTO<bool>>(Apontamentos.CadastrarAvaliadores, avaliador);
        }
        public Node IntanciarAvalaidores(VBoxContainer container)
        {
            var cena = InstanciadorUtil.CarregarCena("res://RES/Cenas/Avaliador.tscn");
            return InstanciadorUtil.InstanciarObjeto(container, cena, null);
        }
    }
}