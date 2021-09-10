using System.Collections.Generic;

using DTO;

namespace DAL.Interface
{
    public interface ICadastroDAL
    {
        void AlterarAcessoDeAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO);
        void CadastrarAvaliador(AvaliadorDTO criterioDTO);
        List<AvaliadorDTO> ListarAvaliador();
        void CadastrarCategoria(CategoriaDTO criterioDTO);
        List<CategoriaDTO> ListarCategoria(string nomeCriterio = "");
        void CadastrarCriterio(CriterioDTO criterioDTO);
        List<CriterioDTO> ListarCriterios(string nomeCriterio = "");
        void CadastrarEscola(EscolaDTO escolaDTO);
        List<EscolaDTO> ListarEscola(string nomeEscola = "");
        void CadastrarTrabalho(TrabalhoDTO criterioDTO);
        List<TrabalhoDTO> ListarTrabalho(string nomeCriterio = "");
    }
}