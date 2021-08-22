using DAO;
using DAL.Interface;

namespace DAL
{
    public class CadastroDAL : ICadastroDAL
    {
        private motic_avaliacaoContext DataContext { get; set; }
        public CadastroDAL(motic_avaliacaoContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}