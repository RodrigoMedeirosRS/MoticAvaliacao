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
        public async Task<RetornoDTO<bool>> LoginAdministrador(LoginDTO loginDTO)
        {
            return new RetornoDTO<bool>();
        }
        public async Task<RetornoDTO<bool>> LoginAvaliador(LoginDTO loginDTO)
        {
            return new RetornoDTO<bool>();
        }
    }
}