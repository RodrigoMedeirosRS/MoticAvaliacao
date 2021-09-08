using Godot;

using DTO;
using BLL.Utils;

namespace CTRL
{
	public class DadosAvaliadorCTRL : Control
	{
		private LineEdit Nome { get ; set; }
		private LineEdit Sobrenome { get ; set; }
		private LineEdit CPF { get ; set; }
		private LineEdit Email { get ; set; }
		private LineEdit Telefone { get ; set; }
		private LineEdit Senha { get ; set; }
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
			Nome = GetNode<LineEdit>("./Nome");
			Sobrenome = GetNode<LineEdit>("./Sobrenome");
			CPF = GetNode<LineEdit>("./CPF");
			Email = GetNode<LineEdit>("./Email");
			Telefone = GetNode<LineEdit>("./Telefone");
			Senha = GetNode<LineEdit>("./Senha");
		}
		public void LimparDados()
		{
			Nome.Text = string.Empty;
			Sobrenome.Text = string.Empty;
			CPF.Text = string.Empty;
			Email.Text = string.Empty;
			Telefone.Text = string.Empty;
			Senha.Text = string.Empty;
		}
		public void PopularDados(AvaliadorDTO avaliadorDTO)
		{
			if (avaliadorDTO == null)
				return;
			Nome.Text = avaliadorDTO.Nome;
			Sobrenome.Text = avaliadorDTO.Sobrenome;
			CPF.Text = avaliadorDTO.CPF;
			Email.Text = avaliadorDTO.Email;
			Telefone.Text = avaliadorDTO.Telefone;
			Senha.Text = avaliadorDTO.Senha;
		}
		public bool ValidarPreenchimento()
		{
			var preenchimento = !string.IsNullOrEmpty(Nome.Text);
			preenchimento = !string.IsNullOrEmpty(Sobrenome.Text);
			preenchimento = !string.IsNullOrEmpty(Email.Text);
			preenchimento = !string.IsNullOrEmpty(Telefone.Text);
			preenchimento = !string.IsNullOrEmpty(Senha.Text);
			try
			{
				ValidadorUtils.ValidarCPF(CPF.Text);
			}
			catch
			{
				preenchimento = false;
			}
			return preenchimento;
		}
		public AvaliadorDTO ObterDadosAvaliador()
		{
			return new AvaliadorDTO()
			{
				Nome = Nome.Text,
				Sobrenome = Sobrenome.Text,
				CPF = CPF.Text,
				Email = Email.Text,
				Telefone = Telefone.Text,
				Senha = Senha.Text
			};
		}
	}	
}
