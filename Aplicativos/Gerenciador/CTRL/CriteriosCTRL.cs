using Godot;
using System.Threading.Tasks;

using DTO;
using BLL;
using BLL.Interface;

namespace CTRL
{
	public class CriteriosCTRL : Tabs
	{
		private AnimationPlayer Animation { get; set; }
		private VBoxContainer CriterioContainer { get; set; }
		private ICriterioBLL CriterioBLL { get ; set; }
		private LineEdit NomeCriterio { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			Task.Run(async () => await PopularCriterios());
		}
		private void PopularNodes()
		{
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
			NomeCriterio = GetNode<LineEdit>("./NovaCriterio/NomeCriterio");
			CriterioContainer = GetNode<VBoxContainer>("./Corpo/CriterioContainer");
		}
		private void RealizarInjecaoDeDependencias()
		{
			CriterioBLL = new CriterioBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private async Task PopularCriterios()
		{
			var criterios = CriterioBLL.ObterCriterios();

			foreach(var criterio in criterios)
			{
				var nodeCriterio = CriterioBLL.IntanciarCriterio(CriterioContainer);
				System.Threading.Thread.Sleep(100);
				(nodeCriterio as CriterioCTRL).DefinirCriterio(criterio);
			}
		}
		private async Task AtualizarCriterios()
		{
			var i = 0;
			foreach(var criterio in CriterioContainer.GetChildren())
			{
				CriterioBLL.AtualizarCriterios((criterio as CriterioCTRL).ObterCriterio(i));
				i ++;
			}
		}
		private void _on_NovaCriterio_button_up()
		{
			Animation.Play("ModalShow");
			NomeCriterio.Text = string.Empty;
		}
		private void _on_SalvarAlteracoes_button_down()
		{
			Task.Run(async () => await AtualizarCriterios());
		}
		private void _on_OK_button_down()
		{
			if (!string.IsNullOrEmpty(NomeCriterio.Text))
			{
				Animation.Play("ModalHide");
				CriterioBLL.AtualizarCriterios(new CriterioDTO()
				{
					Nome = NomeCriterio.Text,
					Ativo = true,
					Peso = CriterioContainer.GetChildCount()
				});
				NomeCriterio.Text = string.Empty;
				LimparCriterios();
				Task.Run(async () => await PopularCriterios());
			}
		}
		private void LimparCriterios()
		{
			foreach(var criterio in CriterioContainer.GetChildren())
				(criterio as CriterioCTRL).QueueFree();
		}
	}
}
