using Godot;
using DTO;

namespace CTRL
{
	public class CategoriaCTRL : Control
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
		public void DefinirCategoria(CategoriaDTO categoriaDTO)
		{
			Nome.Text = categoriaDTO.Nome;
			Ativo.Pressed = categoriaDTO.Ativo;
		}
		public CategoriaDTO ObterCategoria()
		{
			return new CategoriaDTO()
			{
				Nome = Nome.Text,
				Ativo = Ativo.Pressed
			};
		}
	}
}
