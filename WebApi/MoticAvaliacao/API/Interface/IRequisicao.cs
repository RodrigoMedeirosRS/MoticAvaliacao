using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using DTO;

namespace API.Interface
{
    public interface IRequisicao
    {
        Task<RetornoDTO<Saida>> ExecutarRequisicao<Entrada, Saida>(Entrada entrada, Func<Entrada, Task<RetornoDTO<Saida>>> metodo, [CallerMemberName] string nomeMetodo = "");
        Task<RetornoDTO<Saida>> ExecutarRequisicao<Saida>(Func<Task<RetornoDTO<Saida>>> metodo, [CallerMemberName] string nomeMetodo = "");
    }
}