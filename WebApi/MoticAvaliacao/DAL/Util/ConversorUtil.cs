using System;
using System.Collections.Generic;

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
        public static EscolaDTO Mapear(Escola escola)
        {
            return new EscolaDTO()
            {
                Nome = escola.Nome
            };
        }
        public static Escola Mapear(EscolaDTO escola)
        {
            return new Escola()
            {
                Nome = escola.Nome
            };
        }
        public static TrabalhoDTO Mapear(Trabalho trabalho, Categorium categoria, Escola escola)
        {
            return new TrabalhoDTO()
            {
                Nome = trabalho.Nome,
                Escola = Mapear(escola),
                AnoApresentacao = trabalho.Anoapresentacao,
                Categoria = Mapear(categoria)
            };
        }
        public static Trabalho Mapear(TrabalhoDTO trabalhoDTO, CodigoEscolaCategoriaDTO codigo)
        {
            return new Trabalho()
            {
                Nome = trabalhoDTO.Nome,
                Escola = codigo.CodigosEscola,
                Anoapresentacao = trabalhoDTO.AnoApresentacao,
                Categoria = codigo.CodigoCategoria
            };
        }
        public static Avaliacao Mapear(CodigoAvaliadorTrabalhoCriterioDTO codigo)
        {
            return new Avaliacao()
            {
                Avaliador = codigo.CodigoAvaliador,
                Trabalho = codigo.CodigoTrabalho
            };
        }
        public static CriterioAvaliadoDTO Mapear(Criterio criterioAvaliado, Nomecriterio nomeCriterio)
        {
            return new CriterioAvaliadoDTO()
            {
                NomeCriterio = Mapear(nomeCriterio),
                Descricao = criterioAvaliado.Descricao,
                Observacao = criterioAvaliado.Observacao,
                Nota = criterioAvaliado.Nota
            };
        }
    }
}