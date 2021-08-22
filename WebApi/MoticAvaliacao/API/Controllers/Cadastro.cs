using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        
        [HttpPost("CadastrarCategoria")]
        public async Task<RetornoDTO<bool>> CadastrarCategoria(CriterioDTO criterioDTO)
        {
            return Requisicao.ExecutarRequisicao<CriterioDTO, bool>(criterioDTO, BLL.CadastrarCriterio).Result;
        }
    }
}