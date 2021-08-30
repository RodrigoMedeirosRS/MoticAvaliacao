using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using DAO;
using DTO;
using DAL.Utils;
using DAL.Interface;

namespace DAL
{
    public class CadastroDAL : ICadastroDAL
    {
        private motic_avaliacaoContext DataContext { get; set; }
        public CadastroDAL(motic_avaliacaoContext dataContext)
        {
            DataContext = dataContext;
        }
        
#region Administrador
    public void AlterarAcessoDeAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO)
    {
        var acesso = BuscarAcessoAdministrador(alterarAcessoAdministradorDTO);
        if(acesso == null)
            ConcederAcessoAdministrador(alterarAcessoAdministradorDTO.Avaliador);
        else
            RemoverAcessoAdministrador(acesso);
    }

    private void RemoverAcessoAdministrador(Administrador administrador)
    {
        DataContext.Administradors.Remove(administrador);
        DataContext.SaveChanges();
    }

    private void ConcederAcessoAdministrador(AvaliadorDTO avaliador)
    {
        var codigoAvaliador = (from avaliadorCadastrado in DataContext.Avaliadors
            where avaliadorCadastrado.Cpf == avaliador.CPF
            select avaliadorCadastrado).AsNoTracking().FirstOrDefault().Codigo;
        DataContext.Administradors.Add(new Administrador()
        {
            Avaliador = codigoAvaliador
        });
        DataContext.SaveChanges();
    }

    private Administrador BuscarAcessoAdministrador(AlterarAcessoAdministradorDTO alterarAcessoAdministradorDTO)
    {
        return (from avaliador in DataContext.Avaliadors
            join
                administrador in DataContext.Administradors
                on avaliador.Codigo equals administrador.Avaliador
            where avaliador.Cpf == alterarAcessoAdministradorDTO.Avaliador.CPF
            select administrador).AsNoTracking().FirstOrDefault();
    }


#endregion

#region Avaliador
        public void CadastrarAvaliador(AvaliadorDTO avaliadorDTO)
        {
            var avaliador = BuscarAvaliador(avaliadorDTO);
            var novoAvaliador = ConversorUtil.Mapear(avaliadorDTO);
            
            if (avaliador != null)
            {
                novoAvaliador.Codigo = avaliador.Codigo;
                AtualizarAvaliador(novoAvaliador);
            }
            else
                InserirAvaliador(novoAvaliador);
        }
        public List<AvaliadorDTO> ListarAvaliador(string cpf = "")
        {
            return (from avaliador in DataContext.Avaliadors
                where string.IsNullOrEmpty(cpf) ? true : avaliador.Cpf == cpf
                select ConversorUtil.Mapear(avaliador)).AsNoTracking().ToList();
        }
        private void AtualizarAvaliador(Avaliador avaliador)
        {
            DataContext.Avaliadors.Update(avaliador);
            DataContext.SaveChanges();
        }
        private void InserirAvaliador(Avaliador avaliador)
        {
            DataContext.Avaliadors.Add(avaliador);
            DataContext.SaveChanges();
        }
        private Avaliador BuscarAvaliador(AvaliadorDTO avaliadorDTO)
        {
            return (from avaliador in DataContext.Avaliadors
                where avaliador.Cpf == avaliadorDTO.CPF
                select avaliador).AsNoTracking().FirstOrDefault();
        }
#endregion

#region Categoria
        public void CadastrarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = BuscarCategoria(categoriaDTO);
            var novaCategoria = ConversorUtil.Mapear(categoriaDTO);
            
            if (categoria != null)
            {
                novaCategoria.Codigo = categoria.Codigo;
                AtualizarCategoria(novaCategoria);
            }
            else
                InserirCategoria(novaCategoria);
        }
        public List<CategoriaDTO> ListarCategoria(string nomeCategoria = "")
        {
            return (from categoria in DataContext.Categoria
                where string.IsNullOrEmpty(nomeCategoria) ? true : categoria.Nome == nomeCategoria
                select ConversorUtil.Mapear(categoria)).AsNoTracking().ToList();
        }
        private void AtualizarCategoria(Categorium categoria)
        {
            DataContext.Categoria.Update(categoria);
            DataContext.SaveChanges();
        }
        private void InserirCategoria(Categorium categoria)
        {
            DataContext.Categoria.Add(categoria);
            DataContext.SaveChanges();
        }
        private Categorium BuscarCategoria(CategoriaDTO categoriaDTO)
        {
            return (from categoria in DataContext.Categoria
                where categoria.Nome == categoriaDTO.Nome
                select categoria).AsNoTracking().FirstOrDefault();
        }
#endregion

#region Criterio
        public void CadastrarCriterio(CriterioDTO criterioDTO)
        {
            var criterio = BuscarCriterio(criterioDTO);
            var novoCriterio = ConversorUtil.Mapear(criterioDTO);
            
            if (criterio != null)
            {
                novoCriterio.Codigo = criterio.Codigo;
                AtualizarCriterio(novoCriterio);
            }
            else
                InserirCriterio(novoCriterio);
        }
        public List<CriterioDTO> ListarCriterios(string nomeCriterio = "")
        {
            return (from criterio in DataContext.Nomecriterios
                where string.IsNullOrEmpty(nomeCriterio) ? true : criterio.Nome == nomeCriterio
                select ConversorUtil.Mapear(criterio)).AsNoTracking().ToList();
        }
        private void AtualizarCriterio(Nomecriterio criterio)
        {
            DataContext.Nomecriterios.Update(criterio);
            DataContext.SaveChanges();
        }
        private void InserirCriterio(Nomecriterio criterio)
        {
            DataContext.Nomecriterios.Add(criterio);
            DataContext.SaveChanges();
        }
        private Nomecriterio BuscarCriterio(CriterioDTO criterioDTO)
        {
            return (from criterio in DataContext.Nomecriterios
                where criterio.Nome == criterioDTO.Nome
                select criterio).AsNoTracking().FirstOrDefault();
        }
#endregion

#region Trabalho
        public void CadastrarTrabalho(TrabalhoDTO trabalhoDTO)
        {
            var trabalho = BuscarTrabalho(trabalhoDTO);
            var codigos = BuscarCodigoCategoriaEscola(trabalhoDTO);
            var novoTrabalho = ConversorUtil.Mapear(trabalhoDTO, codigos);
            
            if (trabalho != null)
            {
                novoTrabalho.Codigo = trabalho.Codigo;
                AtualizarTrabalho(novoTrabalho);
            }
            else
                InserirTrabalho(novoTrabalho);
        }
        public List<TrabalhoDTO> ListarTrabalho(string nomeTrabalho = "")
        {
            return (from trabalho in DataContext.Trabalhos
                join
                    categoria in DataContext.Categoria
                    on trabalho.Categoria equals categoria.Codigo
                join
                    escola in DataContext.Escolas
                    on trabalho.Escola equals escola.Codigo
                where string.IsNullOrEmpty(nomeTrabalho) ? true : trabalho.Nome == nomeTrabalho
                select ConversorUtil.Mapear(trabalho, categoria, escola)).AsNoTracking().ToList();
        }
        private CodigoEscolaCategoriaDTO BuscarCodigoCategoriaEscola(TrabalhoDTO trabalho)
        {
            var codigoCategoria = BuscarCategoria(trabalho.Categoria).Codigo;
            var codigoEscola = (from escola in DataContext.Escolas
                where trabalho.Escola == escola.Nome
                select escola).AsNoTracking().FirstOrDefault().Codigo;

            return new CodigoEscolaCategoriaDTO()
            {
                CodigoCategoria = codigoCategoria,
                CodigosEscola = codigoEscola
            };
        }
        private void AtualizarTrabalho(Trabalho trabalho)
        {
            DataContext.Trabalhos.Update(trabalho);
            DataContext.SaveChanges();
        }
        private void InserirTrabalho(Trabalho trabalho)
        {
            DataContext.Trabalhos.Add(trabalho);
            DataContext.SaveChanges();
        }
        private Trabalho BuscarTrabalho(TrabalhoDTO trabalhoDTO)
        {
            return (from trabalho in DataContext.Trabalhos
                where trabalho.Nome == trabalhoDTO.Nome
                select trabalho).AsNoTracking().FirstOrDefault();
        }
#endregion
    }
}