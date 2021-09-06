using Godot;
using System;

using DTO;

namespace CTRL
{
	public class EscolaCTRL : Control
	{
		private Label Nome { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void PopularNodes()
		{
			Nome = GetNode<Label>("./Nome");
		}
		public void DefinirEscola(EscolaDTO escolaDTO)
		{
			Nome.Text = escolaDTO.Nome;
		}
		public EscolaDTO ObterEscola(int peso)
		{
			return new EscolaDTO()
			{
				Nome = Nome.Text
			};
		}
	}
}
