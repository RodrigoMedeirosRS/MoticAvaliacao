using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    public class AvaliacaoBLL : IAvaliacaoBLL
    {
        private IAvaliacaoDAL DAL { get; set; }
        public AvaliacaoBLL(IAvaliacaoDAL dal)
        {
            DAL = dal;
        }
    }
}