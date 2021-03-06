using System.Threading.Tasks;
using System.Collections.Generic;

using DTO;

namespace BLL.Interface
{
    public interface ICadastroBLL
    {
        Task<RetornoDTO<bool>> AlterarAcessoDeAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO);
        Task<RetornoDTO<bool>> CadastrarAvaliador(AvaliadorDTO avaliadorDTO);
        Task<RetornoDTO<bool>> CadastrarCategoria(CategoriaDTO categoriaDTO);
        Task<RetornoDTO<bool>> CadastrarCriterio(CriterioDTO criterioDTO);
        Task<RetornoDTO<bool>> CadastrarEscola(EscolaDTO escolaDTO);
        Task<RetornoDTO<bool>> CadastrarTrabalho(TrabalhoDTO trabalhoDTO);
        
        Task<RetornoDTO<List<AvaliadorDTO>>> ListarAvaliadores(ValorDTO cpf = null);
        Task<RetornoDTO<List<CategoriaDTO>>> ListarCategorias(ValorDTO nomeCategoria = null);
        Task<RetornoDTO<List<CriterioDTO>>> ListarCriterios(ValorDTO nomeCriterio = null);
        Task<RetornoDTO<List<EscolaDTO>>> ListarEscola(ValorDTO nomeEscola = null);
        Task<RetornoDTO<List<TrabalhoDTO>>> ListarTrabalhos(ValorDTO nomeTrabalho = null);
    }
}