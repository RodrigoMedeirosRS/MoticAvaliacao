using Godot;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;
using BLL;
using BLL.Utils;
using BLL.Interface;
using BLL.Constantes;

namespace CTRL
{
	public class AvaliadoresCTRL : Tabs
	{
		private static AnimationPlayer Animation { get; set; }
		private static DadosAvaliadorCTRL DadosAvaliador { get; set; }
		private static VBoxContainer Container { get; set; }
		private static IAvaliadoresBLL BLL { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			Task.Run(async () => await PopularAvaliadores());
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new AvaliadoresBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void PopularNodes()
		{
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
			var dadosAvaliador = GetNode<Control>("./DadosAvaliador");
			DadosAvaliador = (dadosAvaliador as DadosAvaliadorCTRL);
			Container = GetNode<VBoxContainer>("./Corpo/AvaliadorContainer");
		}
		private async Task PopularAvaliadores()
		{
			var avaliadores = BLL.ObterAvaliadores();

			foreach(var avaliador in avaliadores)
			{
				var nodeAvaliador = BLL.IntanciarAvalaidores(Container);
				System.Threading.Thread.Sleep(100);
				(nodeAvaliador as AvaliadorCTRL).DefinirAvaliador(avaliador);
			}
		}
		private async Task AtualizarAvaliadores()
		{
			foreach(var avaliador in Container.GetChildren())
			{
				var avaliadorCTRL = (avaliador as AvaliadorCTRL);
				BLL.AtualizarAvaliadores(avaliadorCTRL.ObterAvaliador());		
			}
		}
		private async Task AtualizarAvaliador(AvaliadorDTO avaliador)
		{
			BLL.AtualizarAvaliadores(avaliador);
		}
		private void LimparAvaliadores()
		{
			foreach(var avaliador in Container.GetChildren())
				(avaliador as AvaliadorCTRL).QueueFree();
		}
		private void _on_NovoAvaliador_button_up()
		{
			EditarAvaliador();
		}
		private void _on_OK_button_up()
		{
			if (DadosAvaliador.ValidarPreenchimento())
			{
				var avaliador = DadosAvaliador.ObterDadosAvaliador();
				Animation.Play("ModalHide");
				DadosAvaliador.LimparDados();
				BLL.AtualizarAvaliadores(avaliador);
				LimparAvaliadores();
				Task.Run(async () => await PopularAvaliadores());	
			}
		}
		public static void EditarAvaliador(AvaliadorDTO avaliadorDTO = null)
		{
			if (PodeEditar())
			{
				DadosAvaliador.LimparDados();
				DadosAvaliador.PopularDados(avaliadorDTO);
				Animation.Play("ModalShow");
			}
		}
		public static bool PodeEditar()
		{
			return DadosAvaliador.RectPosition.y != 80;
		}
		public static void AtualizarAdmin(bool admin, AvaliadorDTO avaliadorDTO)
		{
			BLL.AtualizarAcessoAdmin(new AlterarAcessoAdministradorDTO()
			{
				Avaliador = avaliadorDTO,
				ChaveDeAcesso = Apontamentos.ChaveDeAcesso
			});	
		}
	}
}
