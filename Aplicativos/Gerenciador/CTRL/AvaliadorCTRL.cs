using Godot;
using System;

namespace CTRL
{
	public class AvaliadorCTRL : Control
	{
		public override void _Ready()
		{
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void _on_Editar_button_up()
		{
			if (AvaliadoresCTRL.PodeEditar())
				AvaliadoresCTRL.EditarAvaliador();
		}	
	}
}
