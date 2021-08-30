using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DTO;
using BLL.Interface;
using API.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("motic/[controller]")]
    public class Login
    {
        private ILoginBLL BLL { get; set; }
        private IRequisicao Requisicao { get; set; }
        public Login(ILoginBLL bll, IRequisicao requisicao)
        {
            BLL = bll;
            Requisicao = requisicao;
        }

        [HttpPost("LoginAdministrador")]
        public async Task<RetornoDTO<AvaliadorDTO>> LoginAdministrador(LoginDTO loginDTO)
        {
            return Requisicao.ExecutarRequisicao<LoginDTO, AvaliadorDTO>(loginDTO, BLL.LoginAdministrador).Result;
        }
        [HttpPost("LoginAvaliador")]
        public async Task<RetornoDTO<AvaliadorDTO>> LoginAvaliador(LoginDTO loginDTO)
        {
            return Requisicao.ExecutarRequisicao<LoginDTO, AvaliadorDTO>(loginDTO, BLL.LoginAvaliador).Result;
        }
    }
}