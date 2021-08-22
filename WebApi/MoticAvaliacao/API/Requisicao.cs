using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using DTO;
using API.Interface;

namespace API
{
    public class Requisicao : IRequisicao
    {
        public Task<RetornoDTO<Saida>> ExecutarRequisicao<Entrada, Saida>(Entrada entrada, Func<Entrada, Task<RetornoDTO<Saida>>> metodo, [CallerMemberName] string nomeMetodo = "")
        {
            try
            {
                return Task<RetornoDTO<Saida>>.Run(async () => 
                {
                    return await metodo(entrada);
                });
            }
            catch(Exception erro)
            {
                return RetornarErro<Saida>(erro);
            }
        }

        public Task<RetornoDTO<Saida>> ExecutarRequisicao<Saida>(Func<Task<RetornoDTO<Saida>>> metodo, [CallerMemberName] string nomeMetodo = "")
        {
            try
            {
                return Task<RetornoDTO<Saida>>.Run(async () => 
                {
                    return await metodo();
                });
            }
            catch(Exception erro)
            {
                return RetornarErro<Saida>(erro);
            }
        }

        private static Task<RetornoDTO<Saida>> RetornarErro<Saida>(Exception erro)
        {
            return Task<RetornoDTO<Saida>>.Run(async () =>
            {
                return new RetornoDTO<Saida>()
                {
                    Mensagem = erro.Message,
                    Sucesso = false
                };
            });
        }
    }
}