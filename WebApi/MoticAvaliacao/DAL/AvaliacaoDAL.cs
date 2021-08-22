using DAO;
using DAL.Interface;

namespace DAL
{
    public class AvaliacaoDAL : IAvaliacaoDAL
    {
        private motic_avaliacaoContext DataContext { get; set; }
        public AvaliacaoDAL(motic_avaliacaoContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}