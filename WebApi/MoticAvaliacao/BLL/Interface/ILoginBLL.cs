using System.Threading.Tasks;

using DTO;

namespace BLL.Interface
{
    public interface ILoginBLL
    {
        Task<RetornoDTO<bool>> LoginAdministrador(LoginDTO loginDTO);
        Task<RetornoDTO<bool>> LoginAvaliador(LoginDTO loginDTO);
    }
}