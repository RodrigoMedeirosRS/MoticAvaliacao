using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    public class AvaliacaoBLL : IAvaliacaoBLL
    {
        private IAvaliacaoDAL AvaliacaoDAL { get; set; }
        private ICadastroDAL CadastroDAL { get; set; }
        public AvaliacaoBLL(IAvaliacaoDAL avaliacaoDAL, ICadastroDAL cadastroDAL)
        {
            AvaliacaoDAL = avaliacaoDAL;
            CadastroDAL = cadastroDAL;
        }
        public async Task<RetornoDTO<bool>> CadastrarAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            AvaliacaoDAL.CadastrarAvaliacao(avaliacaoDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> RemoverAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            AvaliacaoDAL.RemoverAvaliacao(avaliacaoDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<RetornoListagemAvaliacoesDTO>> ListarAvaliacoes()
        {
            var retorno = new RetornoListagemAvaliacoesDTO();
            
            var categorias = CadastroDAL.ListarCategoria();
            var avaliacoes = AvaliacaoDAL.ListarAvalicoes();
            
            retorno.NaoAvaliados = ClassificarNaoAvaliadas(avaliacoes);
            retorno.AvaliadosPorCategoria = SepararPorCategoria(avaliacoes, categorias);

            return new RetornoDTO<RetornoListagemAvaliacoesDTO>(retorno);
        }

        private List<AvaliacaoDTO> ClassificarNaoAvaliadas(List<AvaliacaoDTO> avaliacoes)
        {
            var naoAvaliados = new List<AvaliacaoDTO>();
            var avaliados = new List<AvaliacaoDTO>();

            foreach (var avaliacao in avaliacoes)
                if (avaliacao.CritariosAvaliados.Count == 0)
                    naoAvaliados.Add(avaliacao);
                else
                    avaliados.Add(avaliacao);

            avaliacoes.Clear();
            avaliacoes = avaliados;
            return naoAvaliados;
        }

        private List<List<AvaliacaoDTO>> SepararPorCategoria(List<AvaliacaoDTO> avaliacoes, List<CategoriaDTO> categorias)
        {
            var resultado = new List<List<AvaliacaoDTO>>();

            foreach(var categoria in categorias)
            {
                var categorizado = Categorizar(avaliacoes, categoria);
                resultado.Add(Rankear(categorizado));
            }

            return resultado;
        }

        private List<AvaliacaoDTO> Categorizar(List<AvaliacaoDTO> avaliacoes, CategoriaDTO categoria)
        {
            var trabalhoNaCategoria = new List<AvaliacaoDTO>();

            foreach(var avaliacao in avaliacoes)
                if (avaliacao.Trabalho.Categoria.Nome == categoria.Nome)
                    trabalhoNaCategoria.Add(avaliacao);

            return trabalhoNaCategoria;
        }

        private List<AvaliacaoDTO> Rankear(List<AvaliacaoDTO> avaliacoes)
        {
            ObterPotuacaoTotal(avaliacoes);
            return avaliacoes.OrderByDescending(avaliacao => avaliacao.Total).ToList();
        }

        private void ObterPotuacaoTotal(List<AvaliacaoDTO> avaliacoes)
        {
            foreach(var avaliacao in avaliacoes)
                avaliacao.Total = ObterNotaTotal(avaliacao);
        }

        private static double ObterNotaTotal(AvaliacaoDTO avaliacao)
        {
             var total = 0.0;

            foreach (var criterio in avaliacao.CritariosAvaliados)
                if (criterio.Nota != null)
                    total += (double)criterio.Nota;
            return total;
        }
    }
}