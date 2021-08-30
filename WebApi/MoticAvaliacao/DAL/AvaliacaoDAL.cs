using System.Linq;
using Microsoft.EntityFrameworkCore;

using DAO;
using DTO;
using DAL.Utils;
using DAL.Interface;

namespace DAL
{
    public class AvaliacaoDAL : IAvaliacaoDAL
    {
        private motic_avaliacaoContext DataContext { get; set; }
        private ICadastroDAL DAL { get ; set; }
        public AvaliacaoDAL(motic_avaliacaoContext dataContext, ICadastroDAL dal)
        {
            DataContext = dataContext;
            DAL = dal;
        }
        public void CadastrarAvalicao(AvaliacaoDTO avaliacaoDTO)
        {
            var avaliacao = BuscarAvaliacao(avaliacaoDTO);
            var codigos = BuscarCodigos(avaliacaoDTO);
            var novaAvalicao = ConversorUtil.Mapear(codigos);
            
            if (avaliacao != null)
            {
                novaAvalicao.Codigo = avaliacao.Codigo;
                AtualizarAvaliacao(novaAvalicao);
            }
            else
                InserirAvaliacao(novaAvalicao);
        }

        private void AtualizarAvaliacao(Avaliacao avaliacao)
        {
            DataContext.Avaliacaos.Update(avaliacao);
            DataContext.SaveChanges();
        }
        private void InserirAvaliacao(Avaliacao avaliacao)
        {
            DataContext.Avaliacaos.Add(avaliacao);
            DataContext.SaveChanges();
        }
        private Avaliacao BuscarAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            return (from avaliacao in DataContext.Avaliacaos
                join
                    avaliador in DataContext.Avaliadors
                    on avaliacao.Avaliador equals avaliador.Codigo
                join
                    trabalho in DataContext.Trabalhos
                    on avaliacao.Trabalho equals trabalho.Codigo
                where avaliador.Cpf == avaliacaoDTO.Avaliador.CPF &&
                    trabalho.Nome == avaliacaoDTO.Trabalho.Nome
                select avaliacao).AsNoTracking().FirstOrDefault();
        }
        private CodigoAvaliadorTrabalhoCriterioDTO BuscarCodigos(AvaliacaoDTO avaliacaoDTO)
        {
            var codigoAvaliador = (from avaliador in DataContext.Avaliadors
                where avaliador.Cpf == avaliacaoDTO.Avaliador.CPF
                select avaliador).AsNoTracking().FirstOrDefault().Codigo;
            var codigoTrabalho = (from trabalho in DataContext.Trabalhos
                where trabalho.Nome == avaliacaoDTO.Trabalho.Nome
                select trabalho).AsNoTracking().FirstOrDefault().Codigo;

            return new CodigoAvaliadorTrabalhoCriterioDTO()
            {
                CodigoAvaliador = codigoAvaliador,
                CodigoTrabalho = codigoTrabalho
            };
        }
    }
}