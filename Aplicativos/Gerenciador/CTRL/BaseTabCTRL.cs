using Godot;
using System;

namespace CTRL
{
	public class BaseTabCTRL : Control
	{
		private Node Tab { get ;set; } 
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
			Tab = GetParent();
		}
		private void _on_TextureButton_button_up()
		{
			Tab.QueueFree();
		}
	}
}
