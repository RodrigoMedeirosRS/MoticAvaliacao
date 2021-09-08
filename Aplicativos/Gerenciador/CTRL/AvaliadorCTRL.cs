using Godot;
using System;

using DTO;

namespace CTRL
{
	public class AvaliadorCTRL : Control
	{
		private AvaliadorDTO Avaliador { get; set; }
		private Label Nome { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Nome = GetNode<Label>("./Nome");
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		public void DefinirAvaliador(AvaliadorDTO avaliadorDTO)
		{
			Nome.Text = avaliadorDTO.Nome + " " + avaliadorDTO.Sobrenome;
			Avaliador = avaliadorDTO;
		}
		public AvaliadorDTO ObterAvaliador()
		{
			return Avaliador;
		}
		private void _on_Editar_button_up()
		{
			if (AvaliadoresCTRL.PodeEditar())
				AvaliadoresCTRL.EditarAvaliador(Avaliador);
		}	
	}
}
