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
                CPF = "",
                Senha = "",
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
        public static CriterioDTO Mapear(Nomecriterio criterio)
        {
            return new CriterioDTO()
            {
                Nome = criterio.Nome,
                Peso = criterio.Peso,
                Ativo = criterio.Ativo,
            };
        }
        public static Nomecriterio Mapear(CriterioDTO criterio)
        {
            return new Nomecriterio()
            {
                Nome = criterio.Nome,
                Peso = criterio.Peso,
                Ativo = criterio.Ativo,
            };
        }
        public static CategoriaDTO Mapear(Categorium categoria)
        {
            return new CategoriaDTO()
            {
                Nome = categoria.Nome,
                Ativo = categoria.Ativo,
            };
        }
        public static Categorium Mapear(CategoriaDTO categoria)
        {
            return new Categorium()
            {
                Nome = categoria.Nome,
                Ativo = categoria.Ativo,
            };
        }
        public static TrabalhoDTO Mapear(Trabalho trabalho, Categorium categoria)
        {
            return new TrabalhoDTO()
            {
                Nome = trabalho.Nome,
                Escola = trabalho.Escola,
                AnoApresentacao = trabalho.Anoapresentacao,
                Categoria = Mapear(categoria)
            };
        }
        public static Trabalho Mapear(TrabalhoDTO trabalhoDTO, int codCategoria)
        {
            return new Trabalho()
            {
                Nome = trabalhoDTO.Nome,
                Escola = trabalhoDTO.Escola,
                Anoapresentacao = trabalhoDTO.AnoApresentacao,
                Categoria = codCategoria
            };
        }
    }
}