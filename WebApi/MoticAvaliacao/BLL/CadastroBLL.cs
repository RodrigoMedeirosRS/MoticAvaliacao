using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;
using BLL.Utils;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    public class CadastroBLL : ChaveDeAcessoUtil, ICadastroBLL
    {
        private ICadastroDAL DAL { get; set; }
        public CadastroBLL(ICadastroDAL dal)
        {
            DAL = dal;
        }
        public async Task<RetornoDTO<bool>> AlterarAcessoDeAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO)
        {
            ValidarChaveDeAcesso(alterarAcessoAdministradorDTO.ChaveDeAcesso);
            DAL.AlterarAcessoDeAdministrador(alterarAcessoAdministradorDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> CadastrarAvaliador(AvaliadorDTO avaliadorDTO)
        {
            DAL.CadastrarAvaliador(avaliadorDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> CadastrarCategoria(CategoriaDTO categoriaDTO)
        {
            DAL.CadastrarCategoria(categoriaDTO);
            return new RetornoDTO<bool>(true);
        }    
        public async Task<RetornoDTO<bool>> CadastrarCriterio(CriterioDTO criterioDTO)
        {
            DAL.CadastrarCriterio(criterioDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> CadastrarEscola(EscolaDTO escolaDTO)
        {
            DAL.CadastrarEscola(escolaDTO);
            return new RetornoDTO<bool>(true);
        }
        public async Task<RetornoDTO<bool>> CadastrarTrabalho(TrabalhoDTO trabalhoDTO)
        {
            DAL.CadastrarTrabalho(trabalhoDTO);
            return new RetornoDTO<bool>(true);
        }
        
        public async Task<RetornoDTO<List<AvaliadorDTO>>> ListarAvaliadores(ValorDTO cpf = null)
        {
            ValidarChaveDeAcesso(cpf.Valor);
            return new RetornoDTO<List<AvaliadorDTO>>(DAL.ListarAvaliador());
        }
        public async Task<RetornoDTO<List<CategoriaDTO>>> ListarCategorias(ValorDTO nomeCategoria = null)
        {
            return new RetornoDTO<List<CategoriaDTO>>(DAL.ListarCategoria(nomeCategoria.Valor));
        }
        public async Task<RetornoDTO<List<CriterioDTO>>> ListarCriterios(ValorDTO nomeCriterio = null)
        {
            return new RetornoDTO<List<CriterioDTO>>(DAL.ListarCriterios(nomeCriterio.Valor));
        }
        public async Task<RetornoDTO<List<EscolaDTO>>> ListarEscola(ValorDTO nomeEscola = null)
        {
            return new RetornoDTO<List<EscolaDTO>>(DAL.ListarEscola(nomeEscola.Valor));
        }
        public async Task<RetornoDTO<List<TrabalhoDTO>>> ListarTrabalhos(ValorDTO nomeTrabalho = null)
        {
            return new RetornoDTO<List<TrabalhoDTO>>(DAL.ListarTrabalho(nomeTrabalho.Valor));
        }
    }
}