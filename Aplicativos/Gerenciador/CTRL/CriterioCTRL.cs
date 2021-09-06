using Godot;

using DTO;

namespace CTRL
{
	public class CriterioCTRL : Control
	{
		private TextureButton Ativo { get ; set; }
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
			Ativo = GetNode<TextureButton>("./Ativo");
			Nome = GetNode<Label>("./Nome");
		}
		public void DefinirCriterio(CriterioDTO categoriaDTO)
		{
			Nome.Text = categoriaDTO.Nome;
			Ativo.Pressed = categoriaDTO.Ativo;
		}
		public CriterioDTO ObterCriterio(int peso)
		{
			return new CriterioDTO()
			{
				Nome = Nome.Text,
				Ativo = Ativo.Pressed,
				Peso = peso
			};
		}
	}
}
