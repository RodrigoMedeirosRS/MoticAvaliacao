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
		}
		private void _on_Categoria_button_up()
		{
			InstanciarTab("res://RES/Cenas/Categorias.tscn", "Categorias");
		}
		private void _on_Criterio_button_up()
		{
			InstanciarTab("res://RES/Cenas/Criterios.tscn", "Criterios");
		}
		private void InstanciarTab(string caminhoTab, string nomeTab)
		{
			BLL.InstanciarTab(Container, caminhoTab, nomeTab);
		}
	}
}
