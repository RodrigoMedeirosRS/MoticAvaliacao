using Godot;
using System;

namespace CTRL
{
	public class AvaliadoresCTRL : Tabs
	{
		private static AnimationPlayer Animation { get; set; }
		private static DadosAvaliadorCTRL DadosAvaliador { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			//Task.Run(async () => await PopularCategorias());
		}
		private void RealizarInjecaoDeDependencias()
		{
			
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
		}
		private void _on_NovoAvaliador_button_up()
		{
			EditarAvaliador();
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			// Replace with function body.
		}
		private void _on_OK_button_up()
		{
			if (DadosAvaliador.ValidarPreenchimento())
			{
				var avaliador = DadosAvaliador.ObterDadosAvaliador();
				Animation.Play("ModalHide");
			}
		}
		public static void EditarAvaliador()
		{
			if (PodeEditar())
			{
				DadosAvaliador.LimparDados();
				Animation.Play("ModalShow");
			}
		}
		public static bool PodeEditar()
		{
			return DadosAvaliador.RectPosition.y != 80;
		}
	}
}
