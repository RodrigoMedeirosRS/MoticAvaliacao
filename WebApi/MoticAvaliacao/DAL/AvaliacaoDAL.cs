using System.Linq;
using System.Collections.Generic;
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
        public void CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO)
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
        public void RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            var avaliacao = BuscarAvaliacao(avaliacaoDTO);
            DataContext.Avaliacaos.Remove(avaliacao);
            DataContext.SaveChanges();
        }
        public List<AvaliacaoDTO> ListarAvalicoes()
        {
            var avaliacoes = ObterAvaliacoes();
            foreach (var avaliacao in avaliacoes)
                avaliacao.CritariosAvaliados = BuscarCriteriosAvaliados(avaliacao.Codigo) ?? new List<CriterioAvaliadoDTO>();
            return avaliacoes;
        }

        private List<AvaliacaoDTO> ObterAvaliacoes()
        {
            return (from avaliacao in DataContext.Avaliacaos
                    join
                        avaliador in DataContext.Avaliadors
                        on avaliacao.Avaliador equals avaliador.Codigo
                    join
                        trabalho in DataContext.Trabalhos
                        on avaliacao.Trabalho equals trabalho.Codigo
                    join
                        categoria in DataContext.Categoria
                        on trabalho.Categoria equals categoria.Codigo
                    join
                        escola in DataContext.Escolas
                        on trabalho.Escola equals escola.Codigo

                    select new AvaliacaoDTO()
                    {
                        Codigo = avaliacao.Codigo,
                        Avaliador = ConversorUtil.Mapear(avaliador),
                        Trabalho = ConversorUtil.Mapear(trabalho, categoria, escola)
                    }).AsNoTracking().ToList();
        }

        private List<CriterioAvaliadoDTO> BuscarCriteriosAvaliados(int codigoAvaliacao)
        {
            return (from criteriosAvaliados in DataContext.Criterios
                join
                    nomeCriterio in DataContext.Nomecriterios
                    on criteriosAvaliados.Nomecriterio equals nomeCriterio.Codigo
                where criteriosAvaliados.Avaliacao == codigoAvaliacao
                select ConversorUtil.Mapear(criteriosAvaliados, nomeCriterio)).AsNoTracking().ToList();
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