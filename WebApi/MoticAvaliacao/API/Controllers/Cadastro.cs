using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DTO;
using BLL.Interface;
using API.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("motic/[controller]")]
    public class Cadastro : ControllerBase
    {
        private ICadastroBLL BLL { get; set; }
        private IRequisicao Requisicao { get; set; }
        public Cadastro(ICadastroBLL bll, IRequisicao requisicao)
        {
            BLL = bll;
            Requisicao = requisicao;
        }

        [HttpPost("AlterarAcessoAdministrador")]
        public async Task<RetornoDTO<bool>> AlterarAcessoAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO)
        {
            return Requisicao.ExecutarRequisicao<AlterarAcessoAdministradorDTO, bool>(alterarAcessoAdministradorDTO, BLL.AlterarAcessoDeAdministrador).Result;
        }

        [HttpPost("CadastrarAvaliador")]
        public async Task<RetornoDTO<bool>> CadastrarAvaliador(AvaliadorDTO avaliadorDTO)
        {
            return Requisicao.ExecutarRequisicao<AvaliadorDTO, bool>(avaliadorDTO, BLL.CadastrarAvaliador).Result;
        }

        [HttpPost("CadastrarCategoria")]
        public async Task<RetornoDTO<bool>> CadastrarCategoria(CategoriaDTO categoriaDTO)
        {
            return Requisicao.ExecutarRequisicao<CategoriaDTO, bool>(categoriaDTO, BLL.CadastrarCategoria).Result;
        }
    
        [HttpPost("CadastrarCriterio")]
        public async Task<RetornoDTO<bool>> CadastrarCriterio(CriterioDTO criterioDTO)
        {
            return Requisicao.ExecutarRequisicao<CriterioDTO, bool>(criterioDTO, BLL.CadastrarCriterio).Result;
        }

        [HttpPost("CadastrarTrabalho")]
        public async Task<RetornoDTO<bool>> CadastrarTrabalho(TrabalhoDTO trabalhoDTO)
        {
            return Requisicao.ExecutarRequisicao<TrabalhoDTO, bool>(trabalhoDTO, BLL.CadastrarTrabalho).Result;
        }

        [HttpPost("ListarAvaliadores")]
        public async Task<RetornoDTO<List<AvaliadorDTO>>> ListarAvaliadores(ValorDTO cpfAvaliador = null)
        {
            return Requisicao.ExecutarRequisicao<ValorDTO, List<AvaliadorDTO>>(cpfAvaliador, BLL.ListarAvaliadores).Result;
        }
        
        [HttpPost("ListarCategorias")]
        public async Task<RetornoDTO<List<CategoriaDTO>>> ListarCategorias(ValorDTO nomeCategoria = null)
        {
            return Requisicao.ExecutarRequisicao<ValorDTO, List<CategoriaDTO>>(nomeCategoria, BLL.ListarCategorias).Result;
        }
        
        [HttpPost("ListarCriterios")]
        public async Task<RetornoDTO<List<CriterioDTO>>> ListarCriterios(ValorDTO nomeCriterio = null)
        {
            return Requisicao.ExecutarRequisicao<ValorDTO, List<CriterioDTO>>(nomeCriterio, BLL.ListarCriterios).Result;
        }
        
        [HttpPost("ListarTrabalhos")]
        public async Task<RetornoDTO<List<TrabalhoDTO>>> ListarTrabalhos(ValorDTO nomeTrabalho = null)
        {
            return Requisicao.ExecutarRequisicao<ValorDTO, List<TrabalhoDTO>>(nomeTrabalho, BLL.ListarTrabalhos).Result;
        }
    }
}