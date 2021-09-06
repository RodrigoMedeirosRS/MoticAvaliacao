using Godot;
using System;

using DTO;
using BLL;
using BLL.Interface;
using BLL.Constantes;

namespace CTRL
{
	public class LoginCTRL : Control
	{
		private Label MensagemErro { get; set; }
		private LineEdit CPF { get; set;}
		private LineEdit Senha { get ; set; }
		private ILogin LoginBLL { get; set; }
		private AnimationPlayer Animation { get ;set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
		}
		public override void _Process(float delta)
		{
			if (Input.IsActionJustPressed("ui_accept"))
				ExecutarLogin();
		}
		private void RealizarInjecaoDeDependencias()
		{
			LoginBLL = new LoginAdministrador();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			//SetProcess(false);
			SetPhysicsProcess(false);
		}
		private void PopularNodes()
		{
			MensagemErro = GetNode<Label>("./Modal/Erro");
			CPF = GetNode<LineEdit>("./Modal/CPF");
			Senha = GetNode<LineEdit>("./Modal/SENHA");
			Animation = GetNode<AnimationPlayer>("./AnimationPlayer");
		}
		private void ExecutarLogin()
		{
			try
			{
				Sessao.AvaliadorLogado = LoginBLL.RealizarLogin(new LoginDTO()
				{
					CPF = CPF.Text,
					Senha = Senha.Text
				});
				Animation.Play("FadeOut");
			}
			catch(Exception ex)
			{
				Animation.Play("Error");
				MensagemErro.Text = ex.Message;
			}
		}
		private void _on_TextureButton_button_up()
		{
			ExecutarLogin();
		}
		private void _on_AnimationPlayer_animation_finished(String anim_name)
		{
			if (anim_name == "FadeOut")
				MainCTRL.CarregarTela("res://RES/Cenas/Dashboard.tscn");
		}
	}
}
