using Godot;
using System;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class MainCTRL : Control
	{
		private static Control Container { get ; set; }
		private static IMainBLL MainBLL { get; set; }	
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			CarregarTela("res://RES/Cenas/Login.tscn");
		}
		private void RealizarInjecaoDeDependencias()
		{
			MainBLL = new MainBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void PopularNodes()
		{
			Container = GetNode<Control>("./Container");
		}
		private void ReposicionarTela()
		{
			if (OS.GetName() != "Android")
			{
				var screen_size = OS.GetScreenSize(0);
				var window_size = OS.WindowSize;
	  			OS.WindowPosition = screen_size * 0.5f - window_size * 0.5f;
			}
		}
		public static void CarregarTela(string caminhoDaTela)
		{
			MainBLL.CarregarCena(Container, caminhoDaTela);
		}
	}
}

