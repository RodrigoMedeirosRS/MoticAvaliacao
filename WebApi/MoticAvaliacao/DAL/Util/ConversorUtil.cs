using System;

using DAO;
using DTO;

namespace DAL.Utils
{
    public static class ConversorUtil
    {
        public static AvaliadorDTO Mapear(Avaliador avaliador)
        {
            return new AvaliadorDTO()
            {
                Nome = avaliador.Nome,
                Sobrenome = avaliador.Sobrenome,
                CPF = avaliador.Cpf,
                Senha = avaliador.Senha,
                Email = avaliador.Email,
                Telefone = avaliador.Telefone
            };
        } 
        public static Avaliador Mapear(AvaliadorDTO avaliador)
        {
            return new Avaliador()
            {
                Nome = avaliador.Nome,
                Sobrenome = avaliador.Sobrenome,
                Cpf = avaliador.CPF,
                Senha = avaliador.Senha,
                Email = avaliador.Email,
                Telefone = avaliador.Telefone
            };
        } 
    }
}