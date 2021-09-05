using System;
using DTO;
using SAL;
using BLL.Utils;
using SAL.Interface;
using BLL.Interface;
using BLL.Constantes;

namespace BLL
{
    public class LoginAdministrador : ILogin
    {
        private IRequisicao SAL { get; set; }

        public LoginAdministrador()
        {
            SAL = new Requisicao();
        }

        public AvaliadorDTO RealizarLogin(LoginDTO login)
        {
            ValidadorUtils.ValidarCPF(login.CPF);
            var retorno = SAL.ExecutarPost<LoginDTO, RetornoDTO<AvaliadorDTO>>(Apontamentos.LoginAdministrador, login);
            return retorno.Conteudo ?? throw new Exception(retorno.Mensagem);
        }
    }
}