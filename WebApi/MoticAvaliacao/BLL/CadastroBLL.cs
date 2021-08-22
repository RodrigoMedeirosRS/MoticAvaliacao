using System.Threading.Tasks;
using System.Collections.Generic;

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
        public async Task<RetornoDTO<bool>> CadastrarAvaliador(AvaliadorDTO avaliadorDTO)
        {
            return new RetornoDTO<bool>();
        }
        public async Task<RetornoDTO<bool>> CadastrarCategoria(CategoriaDTO trabalhoDTO)
        {
            return new RetornoDTO<bool>();
        }
        public async Task<RetornoDTO<bool>> CadastrarTrabalho(TrabalhoDTO trabalhoDTO)
        {
            return new RetornoDTO<bool>();
        }
        public async Task<RetornoDTO<List<AvaliadorDTO>>> ListarAvaliadores(ValorDTO cpf = null)
        {
            return new RetornoDTO<List<AvaliadorDTO>>();
        }
        public async Task<RetornoDTO<List<CriterioDTO>>> ListarCriterios(ValorDTO nomeCriterio = null)
        {
            return new RetornoDTO<List<CriterioDTO>>();
        }
        public async Task<RetornoDTO<List<CategoriaDTO>>> ListarCategorias(ValorDTO nomeCategoria = null)
        {
            return new RetornoDTO<List<CategoriaDTO>>();
        }
        public async Task<RetornoDTO<List<TrabalhoDTO>>> ListarTrabalhos(ValorDTO nomeTrabalho = null)
        {
            return new RetornoDTO<List<TrabalhoDTO>>();
        }
    }
}