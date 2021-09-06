using Godot;
using System;
using System.Threading;
using System.Threading.Tasks;

using BLL;
using DTO;
using BLL.Interface;

namespace CTRL
{
	public class CategoriasCTRL : Tabs
	{
		private AnimationPlayer Animation { get; set; }
		private VBoxContainer CategoriaContainer { get; set; }
		private ICategoriaBLL CategoriaBLL { get ; set; }
		private LineEdit NomeCategoria { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			Task.Run(async () => await PopularCategorias());
		}
		private void PopularNodes()
		{
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
			NomeCategoria = GetNode<LineEdit>("./NovaCategoria/NomeCategoria");
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
				System.Threading.Thread.Sleep(100);
			}
		}
		private async Task AtualizarCategorias()
		{
			foreach(var categoria in CategoriaContainer.GetChildren())
				CategoriaBLL.AtualizarCategorias((categoria as CategoriaCTRL).ObterCategoria());
		}
		private void _on_NovaCategoria_button_up()
		{
			Animation.Play("ModalShow");
			NomeCategoria.Text = string.Empty;
		}
		private void _on_OK_button_up()
		{
			Animation.Play("ModalHide");
			CategoriaBLL.AtualizarCategorias(new CategoriaDTO()
			{
				Nome = NomeCategoria.Text,
				Ativo = true
			});
			NomeCategoria.Text = string.Empty;
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			Task.Run(async () => await AtualizarCategorias());
		}
	}
}
