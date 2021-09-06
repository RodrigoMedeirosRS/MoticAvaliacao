using Godot;
using System;
using System.Threading.Tasks;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class CategoriasCTRL : Tabs
	{
		private VBoxContainer CategoriaContainer { get; set; }
		private ICategoriaBLL CategoriaBLL { get ; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			Task.Run(async () => await PopularCategorias());
		}
		private void PopularNodes()
		{
			CategoriaContainer = GetNode<VBoxContainer>("./Corpo/CategoriaContainer");
		}
		private void RealizarInjecaoDeDependencias()
		{
			CategoriaBLL = new CategoriaBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private async Task PopularCategorias()
		{
			var categorias = CategoriaBLL.ObterCategorias();

			foreach(var categoria in categorias)
			{
				var nodeCategoria = CategoriaBLL.IntanciarCategoria(CategoriaContainer);
				(nodeCategoria as CategoriaCTRL).DefinirCategoria(categoria);
				Task.Delay(100);
			}
		}
		private async Task AtualizarCategorias()
		{
			foreach(var categoria in CategoriaContainer.GetChildren())
				CategoriaBLL.AtualizarCategorias((categoria as CategoriaCTRL).ObterCategoria());
		}
		private void _on_NovaCategoria_button_up()
		{
			// Replace with function body.
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			Task.Run(async () => await AtualizarCategorias());
		}
	}
}
