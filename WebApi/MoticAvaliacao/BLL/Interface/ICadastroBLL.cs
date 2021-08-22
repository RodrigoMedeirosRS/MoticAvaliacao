using System.Threading.Tasks;

using DTO;

namespace BLL.Interface
{
    public interface ICadastroBLL
    {
        Task<RetornoDTO<bool>> CadastrarCriterio(CriterioDTO criterioDTO);
    }
}