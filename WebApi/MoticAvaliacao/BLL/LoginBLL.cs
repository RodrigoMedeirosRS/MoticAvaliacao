using System;
using System.Threading.Tasks;

using DTO;
using DAL.Interface;
using BLL.Interface;

namespace BLL
{
    public class LoginBLL : ILoginBLL
    {
        private ILoginDAL DAL { get; set; }
        public LoginBLL(ILoginDAL dAL)
        {
            DAL = dAL;
        }
        public async Task<RetornoDTO<AvaliadorDTO>> LoginAdministrador(LoginDTO loginDTO)
        {
            return new RetornoDTO<AvaliadorDTO>(AvaliarResultado(DAL.LoginAdministrador(loginDTO)));
        }
        public async Task<RetornoDTO<AvaliadorDTO>> LoginAvaliador(LoginDTO loginDTO)
        {
            return new RetornoDTO<AvaliadorDTO>(AvaliarResultado(DAL.LoginAvaliador(loginDTO)));
        }

        private AvaliadorDTO AvaliarResultado(AvaliadorDTO resultado)
        {
            if (resultado == null)
                throw new Exception(Erros.ErroLogin);
            return resultado;
        }
    }
}