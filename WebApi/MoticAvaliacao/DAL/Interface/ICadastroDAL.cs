using System.Collections.Generic;

using DTO;

namespace DAL.Interface
{
    public interface ICadastroDAL
    {
        void CadastrarAvaliador(AvaliadorDTO criterioDTO);
        List<AvaliadorDTO> ListarAvaliador(string nomeCriterio = "");
        void CadastrarCategoria(CategoriaDTO criterioDTO);
        List<CategoriaDTO> ListarCategoria(string nomeCriterio = "");
        void CadastrarCriterio(CriterioDTO criterioDTO);
        List<CriterioDTO> ListarCriterios(string nomeCriterio = "");
        void CadastrarTrabalho(TrabalhoDTO criterioDTO);
        List<TrabalhoDTO> ListarTrabalho(string nomeCriterio = "");
    }
}