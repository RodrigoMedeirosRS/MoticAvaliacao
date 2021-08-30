using System.Threading.Tasks;

using DTO;

namespace BLL.Interface
{
    public interface ILoginBLL
    {
        Task<RetornoDTO<AvaliadorDTO>> LoginAdministrador(LoginDTO loginDTO);
        Task<RetornoDTO<AvaliadorDTO>> LoginAvaliador(LoginDTO loginDTO);
    }
}