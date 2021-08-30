using System;
namespace BLL.Utils
{
    public abstract class ChaveDeAcessoUtil
    {
        private string ChaveDeAcesso { get; set; } = "N&caM4luca";
        internal protected void ValidarChaveDeAcesso(string chaveDeAcesso)
        {
            if (ChaveDeAcesso != chaveDeAcesso)
                throw new Exception("Acesso Negado");
        }
    }
}