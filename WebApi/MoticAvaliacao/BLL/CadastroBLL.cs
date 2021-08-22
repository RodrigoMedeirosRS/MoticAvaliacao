using System.Threading.Tasks;
using DTO;

using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    public class CadastroBLL : ICadastroBLL
    {
        private ICadastroDAL DAL { get; set; }
        public CadastroBLL(ICadastroDAL dal)
        {
            DAL = dal;
        }
        
        public async Task<RetornoDTO<bool>> CadastrarCriterio(CriterioDTO criterioDTO)
        {
            return new RetornoDTO<bool>();
        }
    }
}