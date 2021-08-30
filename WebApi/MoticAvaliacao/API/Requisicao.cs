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
            return Task<RetornoDTO<Saida>>.Run(async () =>
            {
                try
                {
                    return await metodo(entrada);
                }
                catch(Exception erro)
                {
                    return await RetornarErro<Saida>(erro);
                }
            });
        }
        public Task<RetornoDTO<Saida>> ExecutarRequisicao<Saida>(Func<Task<RetornoDTO<Saida>>> metodo, [CallerMemberName] string nomeMetodo = "")
        {
            return Task<RetornoDTO<Saida>>.Run(async () =>
            {
               try
                {
                    return await metodo();
                }
                catch(Exception erro)
                {
                    return await RetornarErro<Saida>(erro);
                }
            });
        }
        private static async Task<RetornoDTO<Saida>> RetornarErro<Saida>(Exception erro)
        {
            Console.WriteLine(erro);
            return new RetornoDTO<Saida>()
            {
                Mensagem = erro.Message
            };
        }
    }
}