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
    }
}