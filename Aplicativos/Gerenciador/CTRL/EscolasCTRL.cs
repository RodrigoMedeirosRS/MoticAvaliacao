using Godot;
using System;

namespace CTRL
{
	public class EscolasCTRL : Tabs
	{
		private AnimationPlayer Animation { get; set; }
		private VBoxContainer EscolaContainer { get; set; }
		//private ICriterioBLL EscolaBLL { get ; set; }
		private LineEdit NomeEscola { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
			NomeEscola = GetNode<LineEdit>("./NovaEscola/NomeEscola");
			EscolaContainer = GetNode<VBoxContainer>("./Corpo/EscolaContainer");
		}
		private void RealizarInjecaoDeDependencias()
		{
			//CriterioBLL = new CriterioBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void _on_NovaEscola_button_up()
		{
			Animation.Play("ModalShow");
			NomeEscola.Text = string.Empty;
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			// Replace with function body.
		}
		private void _on_OK_button_up()
		{
			if (!string.IsNullOrEmpty(NomeEscola.Text))
			{
				Animation.Play("ModalHide");
				/*
				CriterioBLL.AtualizarCriterios(new CriterioDTO()
				{
					Nome = NomeEscola.Text,
					Ativo = true,
					Peso = EscolaContainer.GetChildCount()
				});
				NomeEscola.Text = string.Empty;
				LimparCriterios();
				Task.Run(async () => await PopularCriterios());
				*/
			}
		}
	}
}
