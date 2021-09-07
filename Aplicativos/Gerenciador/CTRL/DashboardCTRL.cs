using Godot;
using System;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class DashboardCTRL : Control
	{
		private TabContainer Container { get; set; }
		private IDashboardBLL BLL { get; set; }
		private AnimationPlayer Animation { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new DashboardBLL();
		}
		private void PopularNodes()
		{
			Container = GetNode<TabContainer>("./Tabs/TabContainer");
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
		}
		private void _on_Categoria_button_up()
		{
			InstanciarTab("res://RES/Cenas/Categorias.tscn", "Categorias");
		}
		private void _on_Criterio_button_up()
		{
			InstanciarTab("res://RES/Cenas/Criterios.tscn", "Criterios");
		}
		private void _on_Escola_button_up()
		{
			InstanciarTab("res://RES/Cenas/Escolas.tscn", "Escolas");
		}
		private void _on_Avaliador_button_up()
		{
			InstanciarTab("res://RES/Cenas/Avaliadores.tscn", "Avaliadores");
		}
		private void _on_Trabalhos_button_up()
		{
			// Replace with function body.
		}
		private void _on_Avaliacoes_button_up()
		{
			// Replace with function body.
		}
		private void _on_Resultados_button_up()
		{
			// Replace with function body.
		}
		private void _on_Sair_button_up()
		{
			BLL.Sair();
			Animation.Play("FadeOut");
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "FadeOut")
				MainCTRL.CarregarTela("res://RES/Cenas/Login.tscn");
		}
		private void InstanciarTab(string caminhoTab, string nomeTab)
		{
			BLL.InstanciarTab(Container, caminhoTab, nomeTab);
		}
	}
}
