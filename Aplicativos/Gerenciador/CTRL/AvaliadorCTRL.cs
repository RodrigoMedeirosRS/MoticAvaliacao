using Godot;
using System;
using System.Threading.Tasks;

using DTO;
using BLL;
using BLL.Interface;

namespace CTRL
{
	public class AvaliadorCTRL : Control
	{
		private AvaliadorDTO Avaliador { get; set; }
		private Label Nome { get; set; }
		private ILogin BLL { get; set; }
		public bool EhAdmin { get; set; }
		public TextureButton Admin { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Admin = GetNode<TextureButton>("./Administrador");
			EhAdmin = false;
			Nome = GetNode<Label>("./Nome");
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new LoginAdministrador();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetProcess(false);
			SetPhysicsProcess(false);
		}
		public async Task TestarAdmin()
		{
			try
			{
				BLL.RealizarLogin(new LoginDTO(){
					CPF = Avaliador.CPF,
					Senha = Avaliador.Senha
				});
				Admin.Pressed = true;
				EhAdmin = true;
			}
			catch
			{
				Admin.Pressed = false;
				EhAdmin = false;
			}
		}
		public void DefinirAvaliador(AvaliadorDTO avaliadorDTO)
		{
			Nome.Text = avaliadorDTO.Nome + " " + avaliadorDTO.Sobrenome;
			Avaliador = avaliadorDTO;
			Task.Run(async () => await TestarAdmin());
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
