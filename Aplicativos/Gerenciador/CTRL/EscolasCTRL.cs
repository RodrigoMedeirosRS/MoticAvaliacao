using Godot;
using System.Threading.Tasks;

using DTO;
using BLL;
using BLL.Interface;

namespace CTRL
{
	public class EscolasCTRL : Tabs
	{
		private AnimationPlayer Animation { get; set; }
		private VBoxContainer EscolaContainer { get; set; }
		private IEscolaBLL EscolaBLL { get ; set; }
		private LineEdit NomeEscola { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			Task.Run(async () => await PopularEscolas());
		}
		private void PopularNodes()
		{
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
			NomeEscola = GetNode<LineEdit>("./NovaEscola/NomeEscola");
			EscolaContainer = GetNode<VBoxContainer>("./Corpo/EscolaContainer");
		}
		private void RealizarInjecaoDeDependencias()
		{
			EscolaBLL = new EscolaBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private async Task PopularEscolas()
		{
			var escolas = EscolaBLL.ObterEscola();

			foreach(var escola in escolas)
			{
				var nodeEscola = EscolaBLL.IntanciarEscola(EscolaContainer);
				System.Threading.Thread.Sleep(100);
				(nodeEscola as EscolaCTRL).DefinirEscola(escola);
			}
		}
		private void _on_NovaEscola_button_up()
		{
			Animation.Play("ModalShow");
			NomeEscola.Text = string.Empty;
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			Task.Run(async () => await PopularEscolas());
		}
		private void _on_OK_button_up()
		{
			if (!string.IsNullOrEmpty(NomeEscola.Text))
			{
				Animation.Play("ModalHide");
				EscolaBLL.AtualizarEscolas(new EscolaDTO()
				{
					Nome = NomeEscola.Text
				});
				NomeEscola.Text = string.Empty;
				LimparEscolas();
				Task.Run(async () => await PopularEscolas());
			}
		}
		private void LimparEscolas()
		{
			foreach(var escola in EscolaContainer.GetChildren())
				(escola as EscolaCTRL).QueueFree();
		}
	}
}
